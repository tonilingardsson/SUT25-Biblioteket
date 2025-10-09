using System;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating one book
            Book book1 = new Book();
            book1.id = 1;
            book1.title = "Harry Potter";
            book1.totalCopies = 3;
            book1.borrowedCopies = 0;

            // Creating second book
            Book book2 = new Book();
            book2.id = 2;
            book2.title = "Batman";
            book2.totalCopies = 8;
            book2.borrowedCopies = 0;

            // Creating third book
            Book book3 = new Book();
            book3.id = 3;
            book3.title = "Superman";
            book3.totalCopies = 3;
            book3.borrowedCopies = 0;
            
            // Creating fourth book
            Book book4 = new Book();
            book4.id = 4;
            book4.title = "Bamse";
            book4.totalCopies = 8;
            book4.borrowedCopies = 0;

            // Creating fifth book
            Book book5 = new Book();
            book5.id = 5;
            book5.title = "El Quijote";
            book5.totalCopies = 3;
            book5.borrowedCopies = 0;

            // Predifined users
            // Creating first user
            User user1 = new User();
            user1.username = "Petter";
            user1.pin = "1111";
            user1.InitialiseBorrowedBooks();

            // Creating second user
            User user2 = new User();
            user2.username = "Reidar";
            user2.pin = "2222";
            user2.InitialiseBorrowedBooks();

            // Creating third user
            User user3 = new User();
            user3.username = "Sara";
            user3.pin = "3333";
            user3.InitialiseBorrowedBooks();

            // Creating fourth user
            User user4 = new User();
            user4.username = "Pär";
            user4.pin = "4444";
            user4.InitialiseBorrowedBooks();

             // Creating fifth user
            User user5 = new User();
            user5.username = "Antonio";
            user5.pin = "5555";
            user5.InitialiseBorrowedBooks();

            // Welcome message
            System.Console.WriteLine("Välkommen till bibliotekets lånesystem!");
        }
    }    
}
