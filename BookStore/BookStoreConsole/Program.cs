using System;
using BookStore;
using BookStore.Models;
using System.Collections.Generic;
using System.Linq;



namespace BookStoreConsole
{
    class Program
    {
        private static String ohType;
        private static String findBy;
        private static Book book = new Book();
        private static List<Book> books = new List<Book>();



        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            AreArguementsValid(args);
            var oh = new outputHelper();
            if (ohType == "console")
            {
                if (findBy != "title")
                {
                    oh.writeToConsole(books);
                }
                else
                {
                    oh.writeToConsole1(book);
                }
            }
            else if (ohType == "csv")
            {
                Console.WriteLine("Writting to csv file");
                if (findBy != "title")
                {
                    oh.writeToCSV(books);
                }
                else
                {
                    oh.writeToCSV1(book);
                }
            }

        }
        public static void AreArguementsValid(string[] args)
        {
            var ohTypeTemp = args[1].ToLower();
            var findByTemp = args[2].ToLower();
            if (ohTypeTemp == "csv" || ohTypeTemp == "console")
            {
                ohType = ohTypeTemp;
                if (findByTemp == "title" || findByTemp == "author" || findByTemp == "all")
                {
                    findBy = findByTemp;
                    switch (findBy){
                        case "title":
                            {
                                var title = args.ToList();
                                title.RemoveRange(0, 3);
                                var titleStr = string.Join(" ", title.ToArray());
                                Console.WriteLine(titleStr);
                                if (titleStr == "The Travels of Marco Polo" || titleStr == "Canterbury Tales")
                                {
                                    book = BookStoreFunctions.GetBookByTitle(titleStr);
                                }
                                else
                                {
                                    Console.WriteLine("The Travels of Marco Polo or Canterbury Tales");
                                }
                                break;
                            }
                        case "author":
                            {
                                var author = args[3].ToLower();
                                if (author == "polo" || author == "chaucer")
                                {
                                    books = BookStoreFunctions.GetAllAuthorBooks(author);
                                }
                                else
                                {
                                    Console.WriteLine("Polo or Chaucer");
                                }
                                break;
                            }
                        case "all":
                            {
                                books = BookStoreFunctions.GetAllBooks();                              
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("Search by all, title, or author");
                }
            }
            else
            {
                Console.WriteLine("Recieve books by Console or Csv");
            }

        }
    }
}
