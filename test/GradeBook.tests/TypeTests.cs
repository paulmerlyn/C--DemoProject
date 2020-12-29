using System;
using Xunit;

namespace GradeBook.tests
{
    public class TypeTests
    {
        [Fact]
        /* Strings (cf int and bool) are classes, so they are reference types. But strings are immuatable ...
         * and behave like value types. */
        public void StringsBehaveLikeValueTypes() {
            string name = "Scott";
            string upperName = MakeUpperCase(name);
            Assert.Equal("SCOTT", upperName);
        }

        private string MakeUpperCase(string name) {
            return name.ToUpper(); // returns A COPY OF a string converted to upper case. This string method can't modify the original string b/c strings are immutable
        }

        [Fact]
        public void PassingByValueAndByReference() {
            var x = GetInt();
            Assert.Equal(3, x);
            SetInt(x);
            Assert.Equal(3, x);

            SetIntUsingPassByRef(ref x);
            Assert.Equal(42, x);
        }

        private int GetInt() {
            return 3;
        }

        private void SetInt(int x) {
            x = 42;
        }

        private void SetIntUsingPassByRef(ref int x) {
            x = 42;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {

            var book1 = GetBook("Book 1");
            Assert.Equal("Book 1", book1.GetName());

            OverwriteBookNameUsingRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.GetName());
        }

        /* Note: you will rarely want to pass arguments by reference. Passing by value is the default for C-Sharp. Note
         * also that you can use "out" instead of "ref" keyword. The two are similar except that you'll get an 
         * error unless you initialize a parameter whose value is passed via the out keyword. */
        private void OverwriteBookNameUsingRef(ref Book book, string name) {
            book = new Book(name);
        }
        
        [Fact]
        public void BookNameCanBeChanged()
        {

            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.GetName());
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {

            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.GetName());
            Assert.Equal("Book 2", book2.name);
            Assert.NotSame(book1, book2);
            //Assert.Equal("Emma's Grade Book", book.GetName());
        }

        [Fact]
        public void TwoVariablesCanReferenceTheSameObject()
        {

            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2); // This is just a shorthand for Assert.True(Object.ReferenceEquals(obj1, obj2))
            Assert.True(Object.ReferenceEquals(book1, book2)); 
            //Assert.Equal("Emma's Grade Book", book.GetName());
        }


        private Book GetBook(string name) {
            return new Book(name);
        }

        private void SetName(Book book, string name) {
            book.SetName(name);
        }

    }
}
