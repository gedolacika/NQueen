using System;

namespace N_queen
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 8;
            Queens queens = new Queens(N);
            queens.RandomPermutation();
            queens.PrintTable();
            Console.WriteLine();
            Console.WriteLine("Number of collisions on the main diagonal: " + queens.GetNumberOfCollisionsOnTheAllMainDiagonals());
            Console.WriteLine("Number of collisions on the sub diagonal: " + queens.GetNumberOfCollisionsOnTheAllSubDiagonals());
            //for (int i = 0; i < N; ++i) Console.WriteLine(queens.CheckQueenExists(0, i) + " ");
        }
    }
}
