using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.ComputerVision
{
    public static class FloodFill
    {
        public static void FloodFillSimple(int pixX, int pixY, Bitmap image, Color targetColor)
        {
            var floodfillColor = image.GetPixel(pixX, pixY);
            var visitedPixels = new bool[image.Width, image.Height];
            var pixelToBeProcessed = new Stack<Tuple<int, int>>();
            pixelToBeProcessed.Push(Tuple.Create(pixX, pixY));

            while (pixelToBeProcessed.Count > 0)
            {
                var p = pixelToBeProcessed.Pop();

                //Check if pixel has been visited
                if (visitedPixels[p.Item1, p.Item2])
                    continue;

                //Check if pixel has correct color 
                var color = image.GetPixel(p.Item1, p.Item2);

                if (floodfillColor.ToArgb() != color.ToArgb()) continue;

                //Change color 
                image.SetPixel(p.Item1, p.Item2, targetColor);

                //Find neighbors
                GetNeighbors(p, image.Width, image.Height, pixelToBeProcessed);
            }
        }

        public static void FloodFillComparison(int pixX, int pixY, Bitmap image, Color targetColor, Func<Color,Color,bool> isConnected)
        {
            var floodfillColor = image.GetPixel(pixX, pixY);
            var toBeChanged = new bool[image.Width, image.Height];
            var pixelToBeProcessed = new Stack<Tuple<int, int, Color>>();
            var replace = new List<Tuple<int,int,Color>>();
            pixelToBeProcessed.Push(Tuple.Create(pixX, pixY,floodfillColor));

            while (pixelToBeProcessed.Count > 0)
            {
                var p = pixelToBeProcessed.Pop();
                var color = image.GetPixel(p.Item1, p.Item2);
                
                if(toBeChanged[p.Item1, p.Item2]) continue;
                if (!isConnected(p.Item3,color)) continue;

                toBeChanged[p.Item1, p.Item2] = true;

                //Change color
                replace.Add(p);

                //Find neighbors
                GetConnectedNeighbors(p,color,image.Width, image.Height, pixelToBeProcessed);
            }

            //Replace pixels
            foreach (var p in replace)
            {
                image.SetPixel(p.Item1, p.Item2, targetColor);
            }

        }

        private static void GetConnectedNeighbors(Tuple<int, int,Color> p, Color c, int width, int height, 
            Stack<Tuple<int, int,Color>> stack)
        {
            //Up 
            if (p.Item1 > 0)
            {
               stack.Push(Tuple.Create(p.Item1 - 1, p.Item2,c));
            }

            //Down
            if (p.Item1 < width - 1)
            {
                stack.Push(Tuple.Create(p.Item1 + 1, p.Item2,c));
            }

            //Left 
            if (p.Item2 > 0)
            {
                stack.Push(Tuple.Create(p.Item1, p.Item2 - 1,c));
            }

            //Right
            if (p.Item2 < height - 1)
            {
                stack.Push(Tuple.Create(p.Item1, p.Item2 + 1,c));
            }
        }

        private static void GetNeighbors(Tuple<int, int> p, int width, int height, Stack<Tuple<int, int>> stack)
        {
            //Up 
            if (p.Item1 > 0)
            {
                stack.Push(Tuple.Create(p.Item1 - 1, p.Item2));
            }

            //Down
            if (p.Item1 < width - 1)
            {
                stack.Push(Tuple.Create(p.Item1 + 1, p.Item2));
            }

            //Left 
            if (p.Item2 > 0)
            {
                stack.Push(Tuple.Create(p.Item1, p.Item2 - 1));
            }

            //Right
            if (p.Item2 < height - 1)
            {
                stack.Push(Tuple.Create(p.Item1, p.Item2 + 1));
            }
        }
    }
}
