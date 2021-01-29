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
            if (!this.ValidateInputMatrix(matrix))
                return null;

            foreach (var matrixRow in matrix)
            {
                this.FlipAndInvertMatrixRow(matrixRow);
            }

            return matrix;
        }
        /// <summary>
        /// Validates input matrix.
        /// 1 <= A.length = A[0].length <= 20
        /// 0 <= A[i][j] <= 1
        /// </summary>
        /// <param name="matrix">The input matrix.</param>
        /// <returns>The boolean indicates whether the input is valid.</returns>
        public bool ValidateInputMatrix(int[][] matrix)
        {
            // 1 <= A.length = A[0].length <= 20
            if (matrix == null || matrix.Length < 1 || matrix[0].Length > 20 
                || matrix.Length != matrix[0].Length)
                return false;

            // 0 <= A[i][j] <= 1
            foreach (var row in matrix)
            {
                for(var col = 0; col < matrix[0].Length; col++)
                {
                    if (row[col] < 0 && row[col] > 1)
                        return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Flips and inverts a matrix row.
        /// </summary>
        /// <param name="matrixRow">A single row of matrix to be flipped and inverted.</param>
        public void FlipAndInvertMatrixRow(int[] matrixRow)
        {
            var rowLength = matrixRow.Length;
            var mid = (rowLength + 1) / 2;

            for (var col = 0; col < mid; col++)
            {
                var matrixElement = matrixRow[col];                
                matrixRow[col] = this.InvertMatrixElement(matrixRow[rowLength - 1 - col]);
                matrixRow[rowLength - 1 - col] = this.InvertMatrixElement(matrixElement);
            }
        }

        /// <summary>
        /// Inverts a matrix element.
        /// </summary>
        /// <param name="matrixElement">The binary matrix element</param>
        /// <returns>The inserted binary matrix element.</returns>
        public int InvertMatrixElement(int matrixElement)
        {
            return matrixElement ^ 1;
        }

        /// <summary>
        /// Prints the matrix in human-readable format.
        /// </summary>
        /// <param name="matrix">The input matrix to be printed.</param>
        public void PrintMatrix(int[][] matrix)
        {
            for (var i = 0; i < matrix[0].Length; i++)
            {
                if (i == 0)
                    Console.WriteLine("[");

                for (var j = 0; j < matrix[0].Length; j++)
                {
                    if (j == 0)
                        Console.Write("\t[");

                    if (j == matrix[0].Length - 1)
                    {
                        Console.Write("{0}", matrix[i][j]);
                        Console.WriteLine("]");
                    }
                    else
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
