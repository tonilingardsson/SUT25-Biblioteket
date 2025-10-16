using System;

namespace LibrarySystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating Books 2D array: [id, totalCopies, borrowedCopies]
            int[,] books = {
                {1,1,0}, // Harry Potter
                {2,2,0}, // Batman
                {3,3,0}, // Superman
                {4,2,0}, // Bamse
                {5,1,0}  // El quijote
                };

            // Inserting titles
            string[] bookTitles = {
                "Harry Potter",
                "Batman",
                "Superman",
                "Bamse",
                "El Quijote"
            };

            // 2D Array for users
            int[,] users = {
                {0,0,0,0}, // Petter
                {0,0,0,0}, // Reidar
                {0,0,0,0}, // Sara
                {0,0,0,0}, // Pär
                {0,0,0,0}, // Antonio
            };

            // Inserting names as a string into users
            string[] usernames = {"Petter", "Reidar", "Sara", "Pär", "Antonio"};
            // Inserting pins as string (Console.Read() takes strings!) into users
            string[] pins = {"1111", "2222", "3333", "4444", "5555"};

            // Login
            int currentUserIndex = LoginUser(usernames, pins);

            // error handling if the user does not type the right pin
            if (currentUserIndex == -1)
            {
                return; // Failed login
            }

            // Welcome message after login success
            Console.WriteLine($"\nVälkommen, {usernames[currentUserIndex]}!");
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
                    ShowBooks(books, bookTitles);
                    break;
                    // Let the user borrow a book
                    case "2":
                    BorrowBook(books, bookTitles, users, currentUserIndex);
                    break;
                    // Let the user return a book
                    case "3":
                    ReturnBook(books, bookTitles, users, currentUserIndex);
                    break;
                    // Display all the borrowed books, method is done
                    case "4":
                    DisplayUserBorrowedBooks(users, currentUserIndex, usernames, books, bookTitles);;
                    break;
                    // Log out, and communicate to the user
                    case "5":
                    Console.WriteLine("Loggar ut...");
                    userLoggedIn = false;
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

        // Login method. It will return user index or -1 if the inputs are wrong
        static int LoginUser(string[] usernames, string[] pins)
        {
            Console.WriteLine("Välkomen till bibliotekets lånesystem!\n");

            int loginAttempts = 0; // Setting the initial attempts counter to zero

            while (loginAttempts < 3)
            {
                Console.WriteLine("Ange användarnamn: ");
                string inputUsername = Console.ReadLine();

                Console.WriteLine("Ange PIN-kod: ");
                string inputPin = Console.ReadLine();

                // Loop though all users
                for (int i = 0; i < usernames.Length; i++)
                {
                    if(usernames[i] == inputUsername && pins[i] == inputPin)
                    {
                        // Console.WriteLine($"\nVälkommen, {currentUser.username}!");
                        return i; // return user index
                    }
                }

                loginAttempts++;
                if (loginAttempts < 3)
                {
                    Console.WriteLine("Fel användarnamn eller PIN. Försök igen.\n");
                }
            }
            // When the user has tried three times and failed, exit the application.
            Console.WriteLine("För många misslyckade försök. Hej då!");
            return -1;
        }

        // This method will display the books when user chooses 1 on the menu
        static void ShowBooks(int[,] books, string[] bookTitles)
        {
            // Display a menu "header"
            Console.WriteLine("\n=== Tillgängliga böcker ===");

            // Loop though all the books saved above
            for (int i = 0; i < books.GetLength(0); i++)
            {
                // For every book in the library do:
                int id = books[i, 0]; // id saved in 2D array [X, 0]
                int totalCopies = books[i,1]; // # of totalCopies saved in 2D [X,1]
                int borrowedCopies = books[i,2]; // # of borrowedCopies saved in 2D [X,2]
                int available = totalCopies - borrowedCopies;

                System.Console.WriteLine($"[{id}] {bookTitles[i]} - Tillgängliga: {available} av {totalCopies}");
            }
        }

        // This method will display the available books when user chooses 2 on the menu
        static void BorrowBook(int [,] books, string[] bookTitles, int[,] users, int userIndex)
        {
            ShowBooks(books, bookTitles);

            // Asking the user to know which book wants to borrow. Saving a string!
            Console.WriteLine("\nAnge bok-ID för att låna: ");
            string bookIdToBorrow = Console.ReadLine();
            
            // Error handling in case the user enters a wrong book-id. Checking if it's an integer
            if(!int.TryParse(bookIdToBorrow, out int bookId))
            {
                Console.WriteLine("Ogilitgt bok-ID.");
                return;
            }

            // Find the bok-ID through the array
            int bookIndex = -1; // WHY THIS?
            for (int i = 0; i < books.GetLength(0); i++)
            {
                if (books[i,0] == bookId) 
                {
                    bookIndex = i;
                    break;
                }
            }

            // Error handling for wrong bookId
            if (bookIndex == -1)
            {
                System.Console.WriteLine("Bok-ID hittades inte.");
                return;
            }

            // Check if the user can still borrow more books
            int borrowedCount = users[userIndex, 0];
            if (borrowedCount >= 3)
            {
                Console.WriteLine("Du har redan lånat max antal böcker (3).");
                return;
            }
                    
            // Check if there are available copies of the chosen book
            int totalCopies = books[bookIndex, 1];
            int borrowedCopies = books[bookIndex, 2];
            int available = totalCopies - borrowedCopies;

            if(available == 0)
            {
                Console.WriteLine("Boken är inte tillgänglig just nu.");
                return;
            }

            // When user can borrow & there are available copies do this:
            // Add book to the user & display how many available copies are left
            users[userIndex, borrowedCount + 1] = bookId;
            users[userIndex, 0]++; // Increase borrowed count for user
            books[bookIndex, 2]++; // Increased borrowed count for book

            Console.WriteLine($"Du har lånat {bookTitles[bookIndex]}. Välkommen åter!");
        }

        // Return a book
        static void ReturnBook(int[,] books, string[] bookTitles, int[,] users, int userIndex)
        {
            // Show user's borrowed books. Simple, currentUser and the method
            DisplayUserBorrowedBooks(users, userIndex, null, books, bookTitles);

            int borrowedCount = users[userIndex, 0];

            // Check if user has any books, if not, exit
            if (borrowedCount == 0)
            {
                return; // No books to return
            }

            // But if the user has books, the user needs to choose which of own borrowed books to return (if > 1)
            Console.Write("\nAnge bok position för att lämna tillbaka (1-" + borrowedCount + "): ");
            
            // Saving temporarily user's input as a string. Need to convert to an integer. And check it!
            string bookToReturn = Console.ReadLine();

            // Check if user types an integer, validate
            if(!int.TryParse(bookToReturn, out int bookPosition))
            {
                Console.WriteLine("Ogilitgt bok position.");
                return;
            }

            // Error handling if user gives a wrong input (<0 or >borrowedCount)
            if (bookPosition < 1 || bookPosition > borrowedCount)
            {
                Console.WriteLine("Ogiltig position.");
                return;
            }
            
            // Return the book ID 
            int bookIdToReturn = users[userIndex, bookPosition];
            
            // Time to find this bookToReturn's ID in the library, to add it in available
            int bookIndex = -1;
            for (int i = 0; i < books.GetLength(0); i++)
            {
                if (books[i,0] == bookIdToReturn) 
                {
                    // The opposite of what we do when we borrow: i--
                    // Here we decrease the number of copies borrowed for the borrowed book id/index
                    bookIndex = i; // saving the title for dynamic communication
                    break; // exit!
                }
            }

            string bookTitle = bookTitles[bookIndex];

            // Decrease borrowed copies in the library
            books[bookIndex, 2]--;
            
            // Remove from user's borrowed list shifting all the items one position ahead/left
            for (int j = bookPosition; j < borrowedCount; j++)
            {
                users[userIndex, j] = users[userIndex, j + 1];
            }
            // Decrease user's borrowed books count
            users[userIndex, 0]--;
            
            // Step 7: Confirm to user
            Console.WriteLine($"Du har returnerat {bookTitle}. Tack ska du ha!");
        }

        // Display user's borrowed books
        static void DisplayUserBorrowedBooks(int[,] users, int userIndex, string[] usernames, int[,] books, string[] bookTitles)
        {
            // If we found a user, do... CW: user borrowed books
            if (usernames != null)
            {
                System.Console.WriteLine($"\n{usernames[userIndex]}s lånade böcker:");
            }
            else
            {
                System.Console.WriteLine("\nDina lånade böcker");
            }

            // Saved the data into a variable
            int borrowedCount = users[userIndex, 0];

            // If the counter for borrowed is zero, display msg "no books"
            if (borrowedCount == 0) 
            {
                System.Console.WriteLine("Du har inga lånade böcker.");
                return;
            }

            for (int i = 1; i <= borrowedCount; i++)
            {
                // Save the bookId
                int bookIdToReturn = users[userIndex, i]; // save the book ID
                
                // Find the book title
                string bookTitle = ""; // Declare var and assing to "" to avoit nullable
                for (int j = 0; j < books.GetLength(0); j++)
                {
                    if (books[j,0] == bookIdToReturn) 
                    {
                        // If bookId is found, save its Title
                        bookTitle = bookTitles[j];
                        break; // exit!
                    }
                }
            
                System.Console.WriteLine($"- Bok position: {i} | Titel: {bookTitle} | ID: {bookIdToReturn}");
            }
        }
    }    
}