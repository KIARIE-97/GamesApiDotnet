namespace Oop.Models
{
    public class LibraryBook
    {
        string Title { get; set; }
        string Isbn { get; set; }
       public bool IscheckedOut{ get; set; }

        public LibraryBook(string Title, string Isbn)
        {
            this.Title = Title;
            this.Isbn = Isbn;
            IscheckedOut = false;
        }
        //Method
        public void CheckOut()
        {
            if (IscheckedOut) //return true or false
            {
                Console.WriteLine($"{Title} is already checked out.");
            }
            else
            {
                IscheckedOut = true;
                Console.WriteLine($"Successfully checked out {Title}.");
            }
        }
        public void ReturnBook()
        {
            if (!IscheckedOut) //its not
            {
                Console.WriteLine($"{Title} is not checked out. No need to return.");
            }
            else //its 
            {
                IscheckedOut = false;
                Console.WriteLine($"Successfully returned {Title}.");
            }
        }
    }
}