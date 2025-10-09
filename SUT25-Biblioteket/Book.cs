namespace LibrarySystem
{
    public class Book
    {
        // Global properties that will be needed 
        public int id;
           public string title ="";
          public  int totalCopies;
           public int borrowedCopies;
            
            // Calculation of the number of available copies
            public int GetAvailableCopies()  
            {
                return totalCopies - borrowedCopies;
                }

            // Display book info
            public void DisplayBook() 
            {
                System.Console.WriteLine($"[{id}] {title} - Tillgängliga: {GetAvailableCopies()}/{totalCopies} - Utlånade: {borrowedCopies}");
            }          
    }
}
                