using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.Quora
{
    public static class ShortestPathInMaze
    {
        public static int ShortestPathLength = Int32.MaxValue;

        public static void FindShortestPath()
        {
            //Set up maze 
            var m = 10;
            var n = 10;

            var maze = new[,]
            {
                {1,1,1,1,1,0,0,1,1,1}, 
                {0,1,1,1,1,1,0,1,0,1},
                {0,0,1,0,1,1,1,0,0,1},
                {1,0,1,1,1,0,1,1,0,1},
                {0,0,0,1,0,0,0,1,0,1},
                {1,0,1,1,1,0,0,1,1,0},
                {0,0,0,0,1,0,0,1,0,1},
                {0,1,1,1,1,1,1,1,0,0},
                {1,1,1,1,1,0,0,1,1,1},
                {0,0,1,0,0,1,1,0,0,1},
            };

            Move(0,0,7,5,maze);
        }

        public static void Move(int rowCurrent, int colCurrent, int rowEnd, int colEnd, int[,] maze)
        {
            var visited = new bool[maze.GetLength(0), maze.GetLength(1)];
            Move(rowCurrent, colCurrent, rowEnd, colEnd, maze, visited, 0);
        }

        public static void Move(int rowCurrent,int colCurrent,int rowEnd, int colEnd, int[,] maze, bool[,] visited, int pathLength)
        {
            //Check if position is allowed 
            if (maze[rowCurrent, colCurrent]==0) return ;

            //Check if already visited 
            if (visited[rowCurrent,colCurrent])return ;

            visited[rowCurrent, colCurrent] = true;
            pathLength++;

            //Sanity check: print path 
            //PrintPath(visited, maze, pathLength);

            //Check if path is too long 
            if (pathLength>= ShortestPathLength) return ;

            //Check if goal is reached 
            if (rowCurrent == rowEnd && colCurrent == colEnd)
            {
                if (pathLength >= ShortestPathLength) return ;
                ShortestPathLength = pathLength;
                PrintPath(visited,maze,pathLength);
                return;
            }
            //Move up
            CheckMoveBackTrack(rowCurrent, colCurrent + 1, rowEnd, colEnd, maze, visited, pathLength);

            //Move down 
            CheckMoveBackTrack(rowCurrent, colCurrent - 1, rowEnd, colEnd, maze, visited, pathLength);

            //Move left 
            CheckMoveBackTrack(rowCurrent - 1, colCurrent, rowEnd, colEnd, maze, visited, pathLength);

            //Move right 
            CheckMoveBackTrack(rowCurrent + 1, colCurrent, rowEnd, colEnd, maze, visited, pathLength);

          
        }

        private static void CheckMoveBackTrack(int rowCurrent, int colCurrent, int rowEnd, int colEnd, int[,] maze, bool[,] visited, int pathLength)
        {
            if (rowCurrent < 0 || rowCurrent >= maze.GetLength(0) || colCurrent < 0 || colCurrent >= maze.GetLength(1)) return;
            var before = visited[rowCurrent, colCurrent];
            Move(rowCurrent, colCurrent, rowEnd, colEnd, maze, visited, pathLength);
            visited[rowCurrent, colCurrent] = before;
        }

        private static void PrintPath(bool[,] visited,int[,] maze, int pathLength)
        {
            Console.WriteLine("Path length: " + pathLength);
            for (var iRow = 0; iRow < visited.GetLength(0); iRow++)
            {
                for (var iCol = 0; iCol < visited.GetLength(1); iCol++)
                {
                    if (visited[iRow,iCol])
                        Console.Write("X");
                    else
                        Console.Write(maze[iRow,iCol]);
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }
    }
}
