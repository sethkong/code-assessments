using System;

namespace CodeAssessment.Problems
{
    /// <summary>
    /// The {FlipImage} represents flip image blueprint. 
    /// </summary>
    public class FlipImage : IFlipImage
    {
        /// <summary>
        /// Flips and inverts image. First step: flip the matrix by swapping locations of the matrix elements. 
        /// For example, [1, 1, 0] will be [0, 1, 1], [1, 0, 0] will be [0, 0, 1]. There is no value change only 
        /// the position of the elements. 
        /// The second step: invert the matrix element value from 1 to 0 and vice-versa. 
        /// For example, [1, 0, 0] will [0, 1, 1], and [0, 0, 0] will be [1, 1, 1]. 
        /// Strategy: 
        /// 1. To flip the element value, we step through each element of the matrix row
        /// from left and from right and leaves the middle alone. The middle element is (matrixLength + 1) / 2
        /// We plus 1 to the matrix lenth to get the valid index since it starts from 0. 
        /// 2. To invert each element value, we use XOR binary operator to change value from 0 to 1 and vice-versa.
        /// 3. To save space, we are using swap method to update the current matrix without introducing new resuting matrix.
        /// </summary>
        /// <param name="matrix">The input 2D array in form of squared matrix. For example, 1x1, 2x2, 3x3, and 4x4.</param>
        /// <returns>The output matrix whose elements value had been flipped and inverted.</returns>
        public int[][] FlipAndInvertImage(int[][] matrix)
        {
            var matrixLength = matrix[0].Length;
            for (var row = 0; row < matrixLength; row++)
            {
                for (var col = 0; col < (matrixLength + 1) / 2; col++)
                {
                    var tempElement = matrix[row][col] ^ 1;
                    matrix[row][col] = matrix[row][matrixLength - 1 - col] ^ 1;
                    matrix[row][matrixLength - 1 - col] = tempElement;

                }
            }
            return matrix;
        }

        /// <summary>
        /// Prints the matrix in human-readable format.
        /// </summary>
        /// <param name="matrix">The input matrix to be printed.</param>
        public void PrintMatrix(int[][] matrix)
        {
           for(var i = 0; i < matrix[0].Length; i++)
            {
                if (i == 0)
                    Console.WriteLine("[");
                for(var j = 0; j < matrix[0].Length; j++)
                {
                    if (j == 0)
                        Console.Write("\t[");

                    if (j == matrix[0].Length - 1)
                    {
                        Console.Write("{0}", matrix[i][j]);
                        Console.WriteLine("]");
                    } else
                    {
                        Console.Write("{0}, ", matrix[i][j]);
                    }
                }
                if (i == matrix[0].Length - 1)
                    Console.WriteLine("]");
            }
        }
    }
}
