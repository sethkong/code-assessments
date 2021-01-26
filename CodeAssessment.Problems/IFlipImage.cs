namespace CodeAssessment.Problems
{
    /// <summary>
    /// The {IFlipImage} interface represents the flip image blueprint.
    /// </summary>
    public interface IFlipImage
    {
        /// <summary>
        /// Flips and inverts the image. 
        /// </summary>
        /// <param name="matrix">The 2D array</param>
        /// <returns>The flipped 2D array</returns>
        int[][] FlipAndInvertImage(int[][] matrix);

        /// <summary>
        /// Prints the matrix in human-readable format.
        /// </summary>
        /// <param name="matrix">The input matrix to be printed.</param>
        void PrintMatrix(int[][] matrix);
    }
}
