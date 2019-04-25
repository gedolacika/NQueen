using System;
using System.Collections.Generic;
using System.Text;

namespace N_queen
{
    class Queens
    {
        public int N { get; set; }
        //The index means the row and the value equals with the column
        public int[] QueenContainer { get; set; }
        public bool[] BusyPlaces { get; set; }

        public Queens(int N)
        {
            this.N = N;
            QueenContainer = new int[N];
            BusyPlaces = new bool[N];
            for (int i = 0; i < N; ++i) BusyPlaces[i] = false;
        }

        //Fill the array with random elements for each row and col
        public void RandomPermutation()
        {
            Random random = new Random();
            int randomNumber;
            for(int i = 0; i < N; ++i)
            {
                do
                {
                    randomNumber = random.Next(0, N);
                } while (BusyPlaces[randomNumber]);
                if (!BusyPlaces[randomNumber])
                {
                    QueenContainer[i] = randomNumber;
                    BusyPlaces[randomNumber] = true;
                }
            }
        }

        //Return the number of collisions on the whole main diagonals
        public int GetNumberOfCollisionsOnTheAllMainDiagonals()
        {
            int Collisions = 0, CurrentCollision;
            for (int i = 0; i < (2 * N - 1); ++i)
            {
                if (i < N)
                {
                    //row - 0
                    CurrentCollision = CheckMainDiagonalCollisionNumber(0, i);
                    Console.WriteLine(" ({0},{1}) - {2}", 0, i, CurrentCollision);
                }
                else
                {
                    //row - N-1
                    CurrentCollision = CheckMainDiagonalCollisionNumber(N - 1, i - N);
                    Console.WriteLine(" ({0},{1}) - {2}", N - 1, i - N, CurrentCollision);
                }
                if (CurrentCollision >= 2) Collisions += CurrentCollision - 1;
            }
            return Collisions;
        }

        //Return the number of collisions on the whole sub diagonals
        public int GetNumberOfCollisionsOnTheAllSubDiagonals()
        {
            int Collisions = 0, CurrentCollision;
            for (int i = 0; i < (2 * N); ++i)
            {
                if (i < N)
                {
                    //row - 0
                    CurrentCollision = CheckSubDiagonalCollisionNumber(0, i);
                    Console.WriteLine(" ({0},{1}) - {2}", 0, i, CurrentCollision);
                }
                else
                {
                    //row - N-1
                    CurrentCollision = CheckSubDiagonalCollisionNumber(N - 1, i - N+1);
                    Console.WriteLine(" ({0},{1}) - {2}", N - 1, i - N, CurrentCollision);
                }
                if (CurrentCollision >= 2) Collisions += CurrentCollision - 1;
            }
            return Collisions;
        }

        //Check for a pair of (i,j) the collisions on the main diagonal
        public int CheckMainDiagonalCollisionNumber(int row, int col)
        {
            int Collisions = 0, j = 0;
            if (row < col)
            {
                j = col - row;
                for (int i = 0; i < N; ++i)
                {
                    if (j >= 0 && j < N)
                    {
                        if (QueenContainer[i] == j) ++Collisions;
                    }
                    ++j;
                }
            }
            else
            {
                int i = row - col;
                for (j = 0; j < N; ++j)
                {
                    if (i >= 0 && i < N)
                    {
                        // Console.WriteLine("(" + i + "," + )
                        if (QueenContainer[i] == j) ++Collisions;
                    }
                    ++i;
                }
            }

            return Collisions;
        }

        //Check for a pair of (i,j) the collisions on the sub diagonal
        public int CheckSubDiagonalCollisionNumber(int row, int col)
        {
            int Collisions = 0, j = 0;
            if (row < col)
            {
                j = col + row;
                for (int i = 0; i < N; ++i)
                {
                    if (j >= 0 && j < N)
                    {
                        if (QueenContainer[i] == j) ++Collisions;
                    }
                    --j;
                }
            }
            else
            {
                int i = row + col;
                for (j = 0; j < N; ++j)
                {
                    if (i >= 0 && i < N)
                    {
                        // Console.WriteLine("(" + i + "," + )
                        if (QueenContainer[i] == j) ++Collisions;
                    }
                    --i;
                }
            }

            return Collisions;
        }

        public void PrintTable()
        {
            Console.WriteLine();
            Console.WriteLine();
            for(int i = 0; i < QueenContainer.Length; ++i)
            {
                for(int j = 0; j < N; ++j)
                {
                    if(j == QueenContainer[i])
                    {
                        Console.Write(" Q");
                    }
                    else
                    {
                        Console.Write(" +");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool IsAttacked(int row, int col)
        {
            int mainDiagonal, subDiagonal;
            mainDiagonal = CheckMainDiagonalCollisionNumber(row, col);
            subDiagonal = CheckSubDiagonalCollisionNumber(row, col);
            if (mainDiagonal >= 2 || subDiagonal >= 2) return true;
            return false;
        }

        public bool CheckQueenExists(int i, int j)
        {
            bool returnValue = false;
            if (QueenContainer[i] == j) returnValue = true;
            return returnValue;
        }
    }
}
