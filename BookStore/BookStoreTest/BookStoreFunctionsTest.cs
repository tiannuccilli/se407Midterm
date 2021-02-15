using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BookStore;


namespace BookStoreTest
{
    public class BookStoreFunctionsTest
    {
        [Fact]
        public void getBookByTitleTest()
        {
            var result = BookStoreFunctions.GetBookByTitle("Canterbury Tales");
            Assert.True(result.BookId == 2);
        }

        [Fact]
        public void getAllBooks()
        {
            var result = BookStoreFunctions.GetAllBooks();
            Assert.True(result.Count == 2);
        }
        [Fact]
        public void getAllAuthorBooks()
        {
            var result = BookStoreFunctions.GetAllAuthorBooks("Polo");
            Assert.True(result[0].BookTitle == "The Travels of Marco Polo");
        }


    }
}
