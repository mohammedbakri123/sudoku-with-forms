using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudoku_with_forms
{
    using System;

    public class SudokuGame
    {
        public int[,] Matrix { get; private set; }
        private const int Size = 9;

        public SudokuGame()
        {
            Matrix = new int[Size, Size];
            InitializeMatrix();
            GeneratePuzzle();
        }

        private void InitializeMatrix()
        {
            for (int row = 0; row < Size; row++)
                for (int col = 0; col < Size; col++)
                    Matrix[row, col] = 0;
        }

        public void GeneratePuzzle()
        {
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                int row, col, number;
                do
                {
                    row = random.Next(0, Size);
                    col = random.Next(0, Size);
                    number = random.Next(1, Size + 1);
                }
                while (!IsValid(row, col, number));

                Matrix[row, col] = number;
            }
        }

        public bool IsValid(int row, int col, int number)
        {
            return IsValidByRow(row, number) &&
                   IsValidByColumn(col, number) &&
                   IsValidBySubSquare(row, col, number);
        }

        private bool IsValidByRow(int row, int number)
        {
            for (int col = 0; col < Size; col++)
                if (Matrix[row, col] == number)
                    return false;
            return true;
        }

        private bool IsValidByColumn(int col, int number)
        {
            for (int row = 0; row < Size; row++)
                if (Matrix[row, col] == number)
                    return false;
            return true;
        }

        private bool IsValidBySubSquare(int row, int col, int number)
        {
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;

            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    if (Matrix[startRow + r, startCol + c] == number)
                        return false;

            return true;
        }

        public void Reset()
        {
            InitializeMatrix();
            GeneratePuzzle();
        }
    }


}
