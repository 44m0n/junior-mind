using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public class Sudoku
    {
        private const int Nine = 9;
        private const int Three = 3;
        private const int NoOfElements = 81;
        private readonly int[,] sudoku;

        public Sudoku(int[,] sudoku)
        {
            this.sudoku = sudoku;
        }

        public bool Validate()
        {
            CheckParameterIsNull(this.sudoku, nameof(sudoku));
            if (sudoku.Length != NoOfElements)
            {
                throw new ArgumentException("The matrix should contains 81 elements");
            }

            return GetRows(sudoku).All(e => CheckSequence(e)) && GetColumns(sudoku).All(e => CheckSequence(e))
                && GetSquares(sudoku).All(e => CheckSequence(e));
        }

        private IEnumerable<IEnumerable<int>> GetRows(int[,] source)
        {
            return Enumerable.Range(0, Nine).Select(i =>
                        Enumerable.Range(0, Nine).Select(j => source[i, j]));
        }

        private IEnumerable<IEnumerable<int>> GetColumns(int[,] source)
        {
            return Enumerable.Range(0, Nine).Select(i =>
                        Enumerable.Range(0, Nine).Select(j => source[j, i]));
        }

        private IEnumerable<IEnumerable<int>> GetSquares(int[,] source)
        {
            return Enumerable.Range(0, Nine).Select(i =>
                        Enumerable.Range(0, Nine).Select(j =>
                                source[i / Three * Three + j / Three, i % Three * Three + j % Three]));
        }

        private bool CheckSequence(IEnumerable<int> seq)
        {
            return !seq.GroupBy(el => el).Where(e => e.Count() > 1).Select(e => e).Any();
        }

        private void CheckParameterIsNull<T>(T param, string name)
        {
            if (param != null)
            {
                return;
            }

            throw new ArgumentNullException(paramName: name);
        }
    }
}
