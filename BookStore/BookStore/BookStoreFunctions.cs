using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Models;
using System.Linq;

namespace BookStore
{
    public class BookStoreFunctions
    {
        public static Book GetBookByTitle(String titleStr)
        {
            using (var db = new SE407_BookstoreContext())
            {
                return db.Books.Where(b => b.BookTitle == titleStr).FirstOrDefault();
            }
        }
        public static List<Book> GetAllBooks()
        {
            using (var db = new SE407_BookstoreContext())
            {
                return db.Books.ToList();
            }
        }
        public static List<Book> GetAllAuthorBooks(String author)
        {
            using (var db = new SE407_BookstoreContext())
            {
                return db.Books
                .Join(db.Authors,
                 b => b.AuthorId,
                 a => a.AuthorId,
                 (b, a) => new
                 {
                     BookId = b.BookId,
                     BookTitle = b.BookTitle,
                     GenreId = b.GenreId,
                     AuthorId = b.AuthorId,
                     YearOfRelease = b.YearOfRelease,
                     AuthorLast = a.AuthorLast
                 }).Where(w => w.AuthorLast == author)
                 .Select(b => new Book
                 {
                     BookId = b.BookId,
                     BookTitle = b.BookTitle,
                     GenreId = b.GenreId,
                     AuthorId = b.AuthorId,
                     YearOfRelease = b.YearOfRelease
                 }).ToList();
            }
        }
    }
}
