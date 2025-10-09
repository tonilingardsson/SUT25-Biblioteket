using System;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating one book
            Book book1 = new Book();
            book1.Id = 1;
            book1.Title = "Harry Potter";
            book1.TotalCopies = 3;
            book1.BorrowedCopies = 0;

            // Creating second book
            Book book2 = new Book();
            book2.Id = 2;
            book2.Title = "Batman";
            book2.TotalCopies = 8;
            book2.BorrowedCopies = 0;

            // Creating third book
            Book book3 = new Book();
            book3.Id = 3;
            book3.Title = "Superman";
            book3.TotalCopies = 3;
            book3.BorrowedCopies = 0;

            book1.DisplayBook();
            book2.DisplayBook();
            book3.DisplayBook();
        }
    }    
}
