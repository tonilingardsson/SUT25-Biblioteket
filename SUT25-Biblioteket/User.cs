using System;

namespace LibrarySystem
{
    public class User {
        // Store user name and avoid nullable issues 
        public string username = "";
        // A pin/password must be created and stored for login. 
        // Saved as a string!! -> Console.ReadLine()
        public string pin = "";
        // An array to store the user's borrowed books'id
        public int[] borrowedBooks = []; 
        // Counter of borrowed books, to create a max 
        public int borrowedCount = 0;
        // Max of books to be borrowed at once by a user
        public int maxLoans = 3;

        // Method to initialise the borrowed books array
        public void InitialiseBorrowedBooks()
        {
            // Create an array that only takes the book-ids
            borrowedBooks = new int[maxLoans];
        }

        // Method to check if user can borrow more books
        public bool CanBorrowMore() 
        {
            // If returns true, can still borrow; false, STOPS!
            return borrowedCount < maxLoans;
        }

        // Method to display the books the user has borrowed
        public void DisplayBorrowedBooks()
        {
            Console.WriteLine($"\n{username}s lånade böcker:");

            // If statement to display "no books borrowed"
            if (borrowedCount == 0) 
            {
                Console.WriteLine("Inga lånade böcker.");
                return;
            }

            // Display how many books have the user
            for (int i = 0; i < borrowedCount; i++)
            {
                Console.WriteLine($"- Bok ID: {borrowedBooks[i]}");
            }
        }
    }
}