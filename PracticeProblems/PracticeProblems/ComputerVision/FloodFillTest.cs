using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace PracticeProblems.ComputerVision
{
    public static class FloodFillTest
    {
        public static void TestFloodFillBlackAndWhite()
        {
            var folder = @"C:\Git\DataStructures\PracticeProblems\PracticeProblems\ComputerVision";
            var loadFile = Path.Combine(folder, "leafs.png");
            var image = (Bitmap) System.Drawing.Image.FromFile(loadFile);
            FloodFill.FloodFillSimple(10,45, image, Color.BlueViolet);
            var saveFile0 = Path.Combine(folder, "FloodFilledleafs0.png");
            image.Save(saveFile0);
            FloodFill.FloodFillSimple(image.Width / 2, image.Height / 2, image, Color.AliceBlue);
            var saveFile1 = Path.Combine(folder, "FloodFilledleafs1.png");
            image.Save(saveFile1);
        }

        public static void TestFloodFill()
        {
            var folder = @"C:\Git\DataStructures\PracticeProblems\PracticeProblems\ComputerVision";
            var loadFile = Path.Combine(folder, "birds.png");
            var image = (Bitmap)System.Drawing.Image.FromFile(loadFile);
            var maxDiff = 0.02;
            Func<Color,Color,bool> isConnected = (c0, c1) =>
            {
                var rDif = Math.Abs(c0.R - c1.R);
                if (rDif * 1.0 / 255 > maxDiff) return false;
                var gDif = Math.Abs(c0.G - c1.G);
                if (gDif * 1.0 / 255 > maxDiff) return false;
                var bDif = Math.Abs(c0.B - c1.B);
                if (bDif * 1.0 / 255 > maxDiff) return false;
                return true;
            };

            FloodFill.FloodFillComparison(0,0, image, Color.Aqua, isConnected);
            var file = Path.Combine(folder, "FloodFilledWeakConnected.png");
            image.Save(file);
        }

    }
}
