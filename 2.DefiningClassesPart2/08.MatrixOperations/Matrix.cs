namespace MatrixOperations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Matrix<T>
        where T : struct, IComparable, IComparable<T>, IConvertible, IEquatable<T>, IFormattable
    // all those intefaces make sure that the class is a real number
    {
        private T[,] matrix;
        private int rows;
        private int cols;
        
        public Matrix(int rows, int cols)
        {
            if (rows <= 0 || cols <= 0)
            {
                throw new ArgumentException("Rows and/or Columns of matrix cannot be negative or equal to Zero!");
            }
            this.rows = rows;
            this.cols = cols;
            SetSizeOfMatrix();
        }

        public int Rows { get { return this.rows; } }

        public int Cols { get { return this.cols; } }

        private void SetSizeOfMatrix()
        {
            this.matrix = new T[this.rows, this.cols];
        }

        public T this[int row, int col]
        {
            get { return this.matrix[row, col]; }
            set { this.matrix[row, col] = value;  }
        }

        private static void CheckIfSame(int row1, int row2, int col1, int col2)
        {
            if (row1 != row2 || col1 != col2)
            {
                throw new FormatException("Matrices must be same size!");
            }
        }

        public static Matrix<T> operator +(Matrix<T> first, Matrix<T> second)
        {
            CheckIfSame(first.Rows, second.Rows, first.Cols, second.Cols);

            Matrix<T> resultMatrix = new Matrix<T>(first.Rows, first.Cols);
            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int col = 0; col < resultMatrix.Cols; col++)
                {
                    T cell = (dynamic)first[row, col] + second[row, col]; //I don't like dynamic, but did not found other solution
                    resultMatrix[row, col] = cell;
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator -(Matrix<T> first, Matrix<T> second)
        {
            CheckIfSame(first.Rows, second.Rows, first.Cols, second.Cols);
            Matrix<T> resultMatrix = new Matrix<T>(first.Rows, first.Cols);

            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int col = 0; col < resultMatrix.Cols; col++)
                {
                    T cell = (dynamic)first[row, col] - second[row, col]; //I don't like dynamic, but did not found other solution
                    resultMatrix[row, col] = cell;
                }
            }

            return resultMatrix;
        }

        public static Matrix<T> operator *(Matrix<T> first, Matrix<T> second)
        {
            //Ако две матрици А и В са от вид Anxm и Bmxp трябва броят на стълбовете(колоните) на първата матрица да е равен на броя на редовете на втората,
            //за да може произведението А*В да бъде извършено. 
            if (first.Cols != second.Rows)
            {
                throw new FormatException("Multiplying matrices is possible only if (columns of first matrix) = (rows of second matrix)!");
            }

            Matrix<T> resultMatrix = new Matrix<T>(first.Rows, second.Cols);
            for (int row = 0; row < resultMatrix.Rows; row++)
            {
                for (int col = 0; col < resultMatrix.Cols; col++)
                {
                    T cell = (dynamic)0;

                    for (int k = 0; k < first.Cols; k++)
                    {
                        cell += (dynamic)first[row, k] * second[k, col];
                    }

                    resultMatrix[row, col] = cell;
                }
            }

            return resultMatrix;
        }

        public static bool operator true(Matrix<T> matrixToCheck)
        {
            for (int row = 0; row < matrixToCheck.Rows; row++)
            {
                for (int col = 0; col < matrixToCheck.Cols; col++)
                {
                    if (Convert.ToInt32(matrixToCheck[row, col]) == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrixToCheck)
        {
            for (int row = 0; row < matrixToCheck.Rows; row++)
            {
                for (int col = 0; col < matrixToCheck.Cols; col++)
                {
                    if (Convert.ToInt32(matrixToCheck[row, col]) == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder printMatrix = new StringBuilder();

            for (int row = 0; row < this.rows; row++)
            {
                for (int col = 0; col < this.cols; col++)
                {
                    printMatrix.AppendFormat("{0, 4}", matrix[row, col]);
                }

                printMatrix.AppendLine();
            }

            return printMatrix.ToString();
        }
    }
}
