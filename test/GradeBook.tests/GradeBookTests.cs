using System;
using Xunit;

namespace GradeBook.tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class GradeBookTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToAMethod() {
            WriteLogDelegate log;
            log = new WriteLogDelegate(ReturnMessage);
            var result = log("Hello log!");
            Assert.Equal("Hello log!", result);
        }

        private string ReturnMessage(string message) {
            return message;
        }

        [Fact]
        public void BookHoldsAnIdentifyingName()
        {
            //var expected = 11;
            //var actual = 11;

            var book = new Book("Emma's Grade Book");
            Assert.Equal("Emma's Grade Book", book.Name);
        }

        [Fact]
        public void BookCalculatesAnAverageGrade() {
            var book = new Book("Whatever");
            book.AddGrade(3);
            book.AddGrade(5);
            book.AddGrade(10);

            var result = book.GetStatistics();

            Assert.Equal(6, result.GetAverage(), 1);
            Assert.Equal(3, result.GetLow());
            Assert.Equal(10, result.GetHigh());
        }

                [Fact]
        public void BookCalculatesLetterGrade() {
            var book = new Book("Whatever");
            book.AddGrade(80);
            book.AddGrade(85);
            var result = book.GetStatistics();
            Assert.Equal('B', result.GetLetterGrade());
        }

    }
}
