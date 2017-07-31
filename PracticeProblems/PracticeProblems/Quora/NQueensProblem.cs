using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblems.Quora
{
    public class NQueensProblem
    {
        public int Counter;

        /// <summary>
        /// Print all solutions 
        /// </summary>
        public static void PrintAllSolutions()
        {
            var n = 13;

            var pbl = new NQueensProblem();

            var sw = new Stopwatch();
            sw.Start();
            pbl.PlaceQueen2(n);
            var time = sw.ElapsedMilliseconds;
            Console.WriteLine("Number of solutions:" + pbl.Counter);
            Console.WriteLine("Time:" + time);
        }

        public static bool IsSafe(bool[][] board, int r, int c)
        {
            //Check if two queens are in the same column
            for (var iRow = 0; iRow < r; iRow++)
                if (board[iRow][c]) return false;

            //Check if two queens are in the same diagonal 
            for (var i = 1; r-i>=0 && c-i>=0 ;i++)
                if (board[r-i][c-i]) return false;
            
            for (var i = 1; r-i >=0 && c + i< board.Length; i++)
                if (board[r-i][c+i]) return false;

            return true;
        }

        public void PlaceQueen(int n)
        {
            var board = new bool[n][];
            for (var i = 0; i < n; i++)
                board[i] = new bool[n];

            PlaceQueen(board, 0);
        }

        public void PlaceQueen(bool[][] board, int row)
        {
            var n = board.Length;

            //If all queens have been placed, then print them 
            if (row == n)
            {
                //PrintBoard(board);
                Counter++;
            }

            //Try to place queen in next row 
            for (var iCol = 0; iCol < n; iCol++)
            {
                if (!IsSafe(board, row, iCol)) continue;

                //Place queen
                board[row][iCol] = true;

                //Sanity check: Print 
                //PrintBoard(board);

                //Place queen in next row
                PlaceQueen(board, row + 1);

                //Back track
                board[row][iCol] = false;
            }
        }

        public void PlaceQueen2(int n)
        {
            var occupiedColumns = new bool[n];
            var slash = new bool[2*n+1];
            var backSlash = new bool[2*n+1];
            PlaceQueen2(occupiedColumns, slash, backSlash, 0);
        }

        public void PlaceQueen2(bool[] occupiedColumns, bool[] slash, bool[] backSlash, int row)
        {
            var n = occupiedColumns.Length;

            //If all queens have been placed, then print them 
            if (row == n)
            {
                //PrintBoard(board);
                Counter++;
            }

            //Try to place queen in next row 
            for (var col = 0; col < n; col++)
            {
                var slashIndex = row + col;
                var backSlashIndex = row-col + n-1;
                if (occupiedColumns[col]) continue;
                if(backSlash[backSlashIndex]) continue;
                if(slash[slashIndex]) continue;

                //
                var oc = occupiedColumns[col];
                var sla = slash[slashIndex];
                var backSla = backSlash[backSlashIndex];

                //Place queen
                occupiedColumns[col] = true;
                slash[slashIndex] = true;
                backSlash[backSlashIndex] = true;

                //Sanity check: Print 
                //PrintBoard(board);

                //Place queen in next row
                PlaceQueen2(occupiedColumns, slash, backSlash, row + 1);

                //Back track
                occupiedColumns[col] = oc;
                slash[slashIndex] = sla;
                backSlash[backSlashIndex] = backSla;
            }
        }


        public static void PrintBoard(bool[][] board)
        {
            var len = board.Length;

            for (var iRow = 0; iRow < len; iRow++)
            {
                for (var iCol = 0; iCol < len; iCol++)
                {
                    var element = board[iRow][iCol] ? "Q" : "-";
                    Console.Write(element);
                }
                Console.Write(Environment.NewLine);
            }
            Console.Write(Environment.NewLine);
        }
    }
}
