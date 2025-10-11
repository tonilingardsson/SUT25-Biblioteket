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

            // Save the users into an array, simple database
            User[] users = new User[5];
            users[0] = user1;
            users[1] = user2;
            users[2] = user3;
            users[3] = user4;
            users[4] = user5;

            // Save the books into an array, simple database
            Book[] books = new Book[5];
            books[0] = book1;
            books[1] = book2;
            books[2] = book3;
            books[3] = book4;
            books[4] = book5;
            
            // Login system requires variables to make it work
            int loginAttempts = 0;
            bool loggedIn = false;
            User currentUser = user1; // Need this to store the logged-in user after success

            // Welcome message before login
            Console.WriteLine("Välkommen till bibliotekets lånesystem!\n");


            // Login loop with assigned attempts
            while (!loggedIn && loginAttempts < 3)
            {

                // Ask username            
                Console.WriteLine("Ange användarnamn: ");
                string inputUsername = Console.ReadLine();
                
                // Ask the pin
                Console.WriteLine("Ange PIN-kod: ");
                string inputPin = Console.ReadLine();

                // Here the loop to go through all users
                for (int i = 0; i < users.Length; i++)
                // Check if the inputUsername and inputPin match any user
                {
                    // If match found: 1. set currentUser to the user
                // 2. Set loggeIn to true & 3. Break out of the loop
                    if(users[i].username == inputUsername && users[i].pin == inputPin){
                        currentUser = users[i];
                        loggedIn = true;
                        break;
                    }
                }

                if (!loggedIn) 
                {
                    // If no match found after checking all users, do this:
                    loginAttempts++;
                    if (loginAttempts < 3) 
                    {
                        Console.WriteLine("Fel användarnamn eller PIN. Försök igen.");
                    }
                }
            }
            // After a while... xD , checked if logged in
                if(!loggedIn)
                {
                    Console.WriteLine("För många misslyckade försök. Hej då!");
                    return;
                }

            // Welcome message after login success
            Console.WriteLine($"\nVälkommen, {currentUser.username}!");
            bool userLoggedIn = true;

            // Building the Main menu
            while(userLoggedIn)
            {
                Console.WriteLine("\n=== Huvudmeny ===");
                Console.WriteLine("1. Visa böcker");
                Console.WriteLine("2. Låna bok");
                Console.WriteLine("3. Lämna tillbaka bok");
                Console.WriteLine("4. Mina lån");
                Console.WriteLine("5. Logga ut");
                Console.Write("\nVälj ett alternativ (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                    ShowBooks(books);
                    break;
                    case "2":
                    // Todo: call method to borrow a book
                    break;
                    case "3":
                    // Todo: call method to retun a book
                    break;
                    case "4":
                    // Todo: call method to show user's borrowed books
                    break;
                    case "5":
                    // Todo: call method to show books
                    break;
                    default:
                    Console.WriteLine("Ogiltigt val. Välj 1-5.");
                    break;
                }

                // Wait for Enter before showing menu again
                if(userLoggedIn)
                {
                    Console.WriteLine("\nTryck Enter for att återgå till huvudmenyn...");
                    Console.ReadLine();
                }
            }

            // Thank the user for using the system
            Console.WriteLine("Tack för besöket! Hej då!");
        }
        static void ShowBooks(Book[] books)
        {
            // Display a menu "header"
            System.Console.WriteLine("\n=== Tillgängliga böcker ===");

            // Loop though all the books saved above
            foreach (var book in books)
            {
                // Using the method created in Book.cs -> applying SOC
                book.DisplayBook();
            }
        }
    }    
}

