using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.Quora
{
    public static class ShortestPathInMaze
    {
        public static void FindShortestPath()
        {
            //Set up maze 
            int m = 10;
            int n = 10;

            var maze = new int[,]
            {
                {1,1,1,1,1,0,0,1,1,1}, 
                {0,1,1,1,1,1,0,1,0,1},
                {0,0,1,0,1,1,1,0,0,1},
                {1,0,1,1,1,0,1,1,0,1},
                {0,0,0,0,1,0,0,1,0,1},
                {1,0,1,1,1,0,0,1,1,0},
                {0,0,0,0,1,0,0,1,0,1},
                {0,1,1,1,1,1,1,1,0,0},
                {1,1,1,1,1,0,0,1,1,1},
                {0,0,1,0,0,1,1,0,0,1},
            };

            
        }

        public static bool Move(int rowStart,int colStart,int rowEnd, int colEnd, int[,] maze)
        {
            if (rowStart == rowEnd && colStart == colEnd)
            {
                SaveBestPath();
                return true;
            }

            //Check if inside bounds
            if (rowStart < 0 || rowStart>= maze.GetLength(0) || colStart < 0 || colEnd >= maze.GetLength(1)) return false;

            //Make a move 
            CurrentPath
            Move(rowStart - 1, colStart, rowEnd, colEnd, maze);

            {

            }

        }

    }
}
