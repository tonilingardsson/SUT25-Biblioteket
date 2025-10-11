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
                    // Display the books available in the library. Start with 5, add later
                    case "1":
                    ShowBooks(books);
                    break;
                    // Let the user borrow a book
                    case "2":
                    BorrowBook(books, currentUser);
                    break;
                    // Let the user return a book
                    case "3":
                    ReturnBook(books, currentUser);
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
        // This method will display the books when user chooses 1 on the menu
        static void ShowBooks(Book[] books)
        {
            // Display a menu "header"
            Console.WriteLine("\n=== Tillgängliga böcker ===");

            // Loop though all the books saved above
            foreach (var book in books)
            {
                // Using the method created in Book.cs -> applying SOC
                book.DisplayBook();
            }
        }
        // This method will display the available books when user chooses 2 on the menu
        static void BorrowBook(Book[] books, User currentUser)
        {
            ShowBooks(books);

            // Asking the user to know which book wants to borrow. Saving a string!
            Console.WriteLine("\nAnge bok-ID för att låna: ");
            string bookIdToBorrow = Console.ReadLine();
            
            // Error handling in case the user enters a wrong book-id. Checking if it's an integer
            if(!int.TryParse(bookIdToBorrow, out int bookId))
            {
                Console.WriteLine("Ogilitgt bok-ID.");
                return;
            }

            // ID is int, then we search the bok-ID through the array
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].id == bookId) 
                {
                    // Check if the user can still borrow mroe books

                    if (!currentUser.CanBorrowMore())
                    {
                        Console.WriteLine("Du har redan lånat max antal böcker (3).");
                        return;
                    }
                    
                    // Check if there are available copies of the chosen book    
                    if(books[i].GetAvailableCopies() == 0)
                    {
                        Console.WriteLine("Boken är inte tillgänglig just nu.");
                        return;
                    }

                    // When user can borrow & there are available copies do this:
                    // Add book to the user & display how many available copies are left
                    currentUser.borrowedBooks[currentUser.borrowedCount] = books[i].id;
                    currentUser.borrowedCount++;
                    books[i].borrowedCopies++;
                    Console.WriteLine($"Du har lånat {books[i].title}. Välkommen åter!");
                    return; // exit!
                }
            }
            // In case the user enters an integer but it does not match any book-id on the array.
            Console.WriteLine("Bok-ID hittades inte.");
        }

        static void ReturnBook(Book[] books, User currentUser)
        {
            // Show user's borrowed books. Simple, currentUser and the method
            currentUser.DisplayBorrowedBooks();

            // Check if user has any books, if not, exit
            if (currentUser.borrowedCount == 0)
            {
                return;
            }

            // But if the user has books, the user needs to choose which of own borrowed books to return (if > 1)
            Console.WriteLine("\nAnge position för att lämna tillbaka (1-" + currentUser.borrowedCount + "): ");
            // Saving temporarily user's input as a string. Need to convert to an integer. And check it!
            string bookToReturn = Console.ReadLine();

            // Check if user types an integer
            if(!int.TryParse(bookToReturn, out int position))
            {
                Console.WriteLine("Ogilitgt position.");
                return;
            }

            // Error handling if user gives a wrong input (<0 or >borrowedCount)
            if (position < 1 || position > currentUser.borrowedCount)
            {
                Console.WriteLine("Ogiltig position.");
                return;
            }
            
            // Return the book ID from user's array, array's index starts at 0, use -1
            int bookIdToReturn = currentUser.borrowedBooks[position - 1];
            
            // Time to find this bookToReturn's ID in the library, to add it in available
            string bookToReturnTitle = ""; // I want to display a dynamic message to the user with the book title
            for (int i = 0; i < books.Length; i++)
            {
                if (books[i].id == bookIdToReturn) 
                {
                    // The opposite of what we do when we borrow: i--
                    // Here we decrease the number of copies borrowed for the borrowed book id/index
                    bookToReturnTitle = books[i].title; // saving the title for dynamic communication
                    books[i].borrowedCopies--;
                    break; // exit!
                }
            }
            
            // Remove from user's borrowed list shifting all the items one position ahead/left
            for (int j = position -1; j < currentUser.borrowedCount - 1; j++)
            {
                currentUser.borrowedBooks[j] = currentUser.borrowedBooks[j+1];
            }
            currentUser.borrowedCount--;
            
            // Step 7: Confirm to user
            Console.WriteLine($"Du har returnerat {bookToReturnTitle}. Tack ska du ha!");

        }
    }    
}

