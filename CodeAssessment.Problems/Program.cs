using System;

namespace CodeAssessment.Problems
{
    /// <summary>
    /// The driver/entry point program for the Code Assessment application.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts and runs the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            var flipImage = new FlipImage();

            var matrix1 = new int[4][]
               {
                    new int[] {1, 0, 1, 0 },
                    new int[] { 0, 0, 1, 1},
                    new int[] { 1, 1, 1, 1 },
                    new int[] {0, 0, 0, 0 }
               };

            var matrix2 = new int[3][]
                {
                    new int[] {1, 1, 0},
                    new int[] {1, 0, 1},
                    new int[] {0, 0, 0}
                };

            Console.WriteLine("The input matrix 1");
            flipImage.PrintMatrix(matrix1);
            var outputMatrix1 = flipImage.FlipAndInvertImage(matrix1);
            Console.WriteLine("The output matrix 1 after flipped and inverted");
            flipImage.PrintMatrix(outputMatrix1);

            Console.WriteLine("The input matrix 2");
            flipImage.PrintMatrix(matrix2);
            var outputMatrix2 = flipImage.FlipAndInvertImage(matrix2);
            Console.WriteLine("The output matrix 2 after flipped and inverted");
            flipImage.PrintMatrix(outputMatrix2);
        }
    }
}
