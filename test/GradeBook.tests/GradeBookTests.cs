using System;
using Xunit;

namespace GradeBook.tests
{
    public class GradeBookTests
    {
        [Fact]
        public void Test1()
        {
            //var expected = 11;
            //var actual = 11;

            var book = new Book("Emma's Grade Book");
            Assert.Equal("Emma's Grade Book", book.GetName());
        }

        [Fact]
        public void Test2() {
            var book = new Book("Whatever");
            book.AddGrade(3);
            book.AddGrade(5);
            book.AddGrade(10);

            var result = book.GetStatistics();

            Assert.Equal(6, result.GetAverage(), 1);
            Assert.Equal(3, result.GetLow());
            Assert.Equal(10, result.GetHigh());
        }
    }
}
