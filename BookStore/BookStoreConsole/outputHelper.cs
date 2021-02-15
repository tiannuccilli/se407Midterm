using BookStore.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace BookStoreConsole
{
    class outputHelper
    {
        public void writeToConsole(List<Book> books)
        {
            foreach (var b in books)
            {
                Console.WriteLine($"Book ID: {b.BookId}    Title: {b.BookTitle}  Genre ID: {b.GenreId} Author ID: {b.AuthorId} Release Year:{b.YearOfRelease}");

            }
        }
        public void writeToConsole1(Book book)
        {
            Console.WriteLine($"Book ID: {book.BookId}    Title: {book.BookTitle}  Genre ID: {book.GenreId} Author ID: {book.AuthorId} Release Year:{book.YearOfRelease}");
        }

        public void writeToCSV(List<Book> books)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(books);
            }
        }
        public void writeToCSV1(Book book)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecord(book);
            }
        }
    }
}
