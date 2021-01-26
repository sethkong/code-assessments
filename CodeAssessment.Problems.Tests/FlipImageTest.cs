using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CodeAssessment.Problems.Tests
{
    /// <summary>
    /// The {FlipImageTest} represents the unit test for {FlipImage}
    /// </summary>
    [TestClass]
    public class FlipImageTest
    {
        /// <summary>
        /// The input matrix 1 represents the 4x4 matrix.
        /// </summary>
        int[][] Matrix1;

        /// <summary>
        /// The input matrix 2 represents the 3x3 matrix.
        /// </summary>
        int[][] Matrix2;

        /// <summary>
        /// The expected output for input matrix 1.
        /// </summary>
        int[][] expectedMatrix1;

        /// <summary>
        /// The expected output for input matrix 2.
        /// </summary>
        int[][] expectedMatrix2;

        private IFlipImage flipImage;

        /// <summary>
        /// Initializes and accquires resources for testing to verify the correction of 
        /// the {FlipImage}.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this.Matrix1 = new int[4][]
            {
                new int[] {1, 0, 1, 0 },
                new int[] { 0, 0, 1, 1},
                new int[] { 1, 1, 1, 1 },
                new int[] {0, 0, 0, 0 }
            };

            this.Matrix2 = new int[3][]
            {
                new int[] {1, 1, 0},
                new int[] {1, 0, 1},
                new int[] {0, 0, 0}
            };

            this.expectedMatrix1 = new int[4][]
            {
                new int[] {1, 0, 1, 0},
                new int[] {0, 0, 1, 1},
                new int[] {0, 0, 0, 0},
                new int[] {1, 1, 1, 1}
            };

            this.expectedMatrix2 = new int[3][]
            {
                new int[] {1, 0, 0},
                new int[] {0, 1, 0},
                new int[] {1, 1, 1}
            };

            this.flipImage = new FlipImage();
        }

        /// <summary>
        /// Cleans up the testing resources.
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            Array.Clear(this.Matrix1, 0, this.Matrix1.Length);
            Array.Clear(this.Matrix2, 0, this.Matrix2.Length);
        }

        /// <summary>
        /// Tests the validity of FlipAndInvertImage() method.
        /// </summary>
        [TestMethod]
        public void TestFlipAndInvertImage()
        {
            var outputMatrix1 = this.flipImage.FlipAndInvertImage(this.Matrix1);
            var outputMatrix2 = this.flipImage.FlipAndInvertImage(this.Matrix2);
            Assert.IsTrue(this.IsMatrixEqual(outputMatrix1, this.expectedMatrix1));
            Assert.IsTrue(this.IsMatrixEqual(outputMatrix2, this.expectedMatrix2));
        }

        /// <summary>
        /// Compares if the two given matrices are equal. The comparison only takes into consideration 
        /// the matrix lement values and NOT the instances of the object equality.
        /// </summary>
        /// <param name="matrix1">The input matrix 1.</param>
        /// <param name="matrix2">The input matrix 2.</param>
        /// <returns>The boolean value indicates whether the two matrices are equal.</returns>
        private bool IsMatrixEqual(int[][] matrix1, int[][] matrix2)
        {
            if (matrix1[0].Length != matrix2[0].Length || matrix1.Length != matrix2.Length)
                return false;

            for (var r = 0; r < matrix1[0].Length; r++)
            {
                for (var c = 0; c < matrix1[0].Length; c++)
                {
                    if (matrix1[r][c] != matrix2[r][c])
                        return false;
                }
            }
            return true;
        }
    }
}
