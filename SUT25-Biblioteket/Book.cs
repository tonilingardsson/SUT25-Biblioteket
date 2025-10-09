namespace LibrarySystem
{
    public class Book
    {
        // Global properties that will be needed 
        public int Id;
           public string Title ="";
          public  int TotalCopies;
           public int BorrowedCopies;
            
            // Calculation of the number of available copies
            public int GetAvailableCopies()  
            {
                return TotalCopies - BorrowedCopies;
                }

            // Display book info
            public void DisplayBook() 
            {
                System.Console.WriteLine($"[{Id}] {Title} - Tillgängliga: {GetAvailableCopies()}/{TotalCopies} - Utlånade: {BorrowedCopies}");
            }          
    }
}
                