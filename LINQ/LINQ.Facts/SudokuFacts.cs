using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LINQ.Facts
{
    public class SudokuFacts
    {
        [Fact]
        public void SudokuTest()
        {
            int[,] sudoku =
            {
                { 2,4,4,3,3,5,9,6,7 },
                { 6,2,8,3,2,6,1,7,6 },
                { 7,6,7,7,3,5,5,6,8 },
                { 1,7,5,3,7,5,7,7,3 },
                { 3,3,1,8,1,1,5,8,4 },
                { 7,5,2,7,2,4,2,3,7 },
                { 5,9,1,2,4,9,7,9,4 },
                { 8,6,3,1,4,8,3,6,8 },
                { 9,4,4,8,1,4,5,5,7 }
            };

            var obj = new Sudoku(sudoku);
            Assert.False(obj.Validate());

            sudoku = new int[,]
            {
                { 4, 8, 9, 2, 5, 7, 6, 3, 1, },
                { 7, 1, 3, 4, 9, 6, 8, 5, 2, },
                { 6, 2, 5, 3, 8, 1, 4, 9, 7, },
                { 2, 6, 1, 9, 3, 8, 5, 7, 4, },
                { 5, 3, 7, 1, 2, 4, 9, 8, 6, },
                { 8, 9, 4, 7, 6, 5, 1, 2, 3, },
                { 9, 4, 6, 8, 7, 3, 2, 1, 5, },
                { 1, 7, 2, 5, 4, 9, 3, 6, 8, },
                { 3, 5, 8, 6, 1, 2, 7, 4, 9, }
            };

            obj = new Sudoku(sudoku);
            Assert.True(obj.Validate());
        }
    }
}
