namespace MatrixOperations
{
    using System;

    class TestingMatrix
    {
        static void Main()
        {
            Matrix<int> matrix = new Matrix<int>(4, 4);
            Matrix<int> matrixTwo = new Matrix<int>(4, 4);

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    matrix[i, j] = i + j;
                    matrixTwo[i, j] = (i - j) * 5;
                }
            }
            //matrix[2, 2] = 10;
            //Console.WriteLine(matrix[2, 2]);
            //Console.WriteLine(matrix[0, 2]);

            //Printing whole matrix: Overriden ToString() method. 
            Console.WriteLine("First matrix: \n" + matrix);
            Console.WriteLine("Second matrix: \n" + matrixTwo);

            //Testing operators
            Matrix<int> resultSum = matrix + matrixTwo;
            Console.WriteLine("Sum of two matrices is:\n" + resultSum);

            Matrix<int> resultSubstract = matrix - matrixTwo;
            Console.WriteLine("Substract of two matrices is:\n" + resultSubstract);

            Matrix<int> resultProduct = matrix * matrixTwo;
            Console.WriteLine("Product of two matrices is:\n" + resultProduct);

            //Testing true and false
            Console.WriteLine(resultProduct ? "There are no zeros in the matrix above." : "There is at least one Zero in the matrix above.");
            Console.WriteLine(resultProduct + resultSubstract);
            Console.WriteLine((resultProduct + resultSubstract) ? "There are no zeros in the matrix above." : "There is at least one Zero in the matrix above.");
        }
    }
}
