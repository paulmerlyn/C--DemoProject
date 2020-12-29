using System;
using Xunit;

namespace GradeBook.tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class GradeBookTests
    {
        int count = 0; // default access-control-level is private

        [Fact]
        public void WriteLogDelegateCanPointToAMethod() {
            WriteLogDelegate log = ReturnMessage;
            //log = new WriteLogDelegate(ReturnMessage); // This is the long-hand syntax for assigning a method to a delegate
            log = ReturnMessage; // This is the alternative short-hand syntax!
            
            log += IncrementCountAndLowerCase;
            var result = log("Hello log!");
            Assert.Equal("hello log!", result);
        }

        [Fact]
        public void CountHasIncrementedWithForEachDelegatedCall() {
            WriteLogDelegate log = IncrementCountAndLowerCase;
            log += IncrementCountAndLowerCase;
            log += IncrementCountAndLowerCase;
            log += IncrementCountAndLowerCase;
            var result = log("Test the counter");
            Assert.Equal(4, count);
        }

        private string ReturnMessage(string message) {
            count++;
            return message;
        }

        private string IncrementCountAndLowerCase(string message) {
            count++;
            return message.ToLower();
        }

        [Fact]
        public void BookHoldsAnIdentifyingName()
        {
            //var expected = 11;
            //var actual = 11;

            var book = new InMemoryBook("Emma's Grade Book");
            Assert.Equal("Emma's Grade Book", book.Name);
        }

        [Fact]
        public void BookCalculatesAnAverageGrade() {
            var book = new InMemoryBook("Whatever");
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
            var book = new InMemoryBook("Whatever");
            book.AddGrade(80);
            book.AddGrade(85);
            var result = book.GetStatistics();
            Assert.Equal('B', result.GetLetterGrade());
        }

    }
}
