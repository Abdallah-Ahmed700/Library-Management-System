namespace Library_Management_System
{
    class Library
    {
        List<Book> books;

        public Library()
        {
            books = new List<Book>();
        }
        public string AddBook(Book book)
        {
            books.Add(book);
            return "Book added successfully.";
        }


        public Book SearchBook(string serch)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if ((books[i].title).ToUpper() == serch.ToUpper() || (books[i].iSBN).ToUpper() == serch.ToUpper())
                {

                    return books[i];
                }
            }
            return null;
        }
        public bool BorrowBook(string bb)
        {
            Book book= SearchBook(bb);
            if (book != null && book.availability)
            {
                book.availability = false;
                return true;
            }          
                return false;
        }
        public bool ReturnBook(string rb) 
        { 
            Book book= SearchBook(rb);
            if (book != null && !book.availability)
            {
                book.availability = true;
                return true;
            }
            return false;
        }


    }


    class Book
    {
        public string title;
        public string author;
        public string iSBN;
        public bool availability;

        public Book(string title, string author, string iSBN)
        {
           this.title   = title;
           this.author  = author;
           this.iSBN    = iSBN;
           availability = true;
        }  

    }




    internal class Program
    {

        static void Main(string[] args)
        {

            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));

            // Searching and borrowing books
            Console.WriteLine("Searching and borrowing books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("\nReturning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();



        }
    }
}
