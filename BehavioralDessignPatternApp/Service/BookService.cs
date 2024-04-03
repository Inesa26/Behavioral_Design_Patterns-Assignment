using BehavioralDessignPatternApp.Model;
using BehavioralDessignPatternApp.Repository;

namespace BehavioralDessignPatternApp.Service
{
    public class BookService
    {
        private IRepository<Book> _repository;
        public static BookService? _instance;
        private readonly List<Book> _booksForSale = new List<Book>();
        private BookService()
        {
            _repository = new RepositoryImpl<Book>(new List<Book>() {
            new Book { Id = 1, Title = "Fahrenheit 451", Author = "Ray Bradbury", Genre = "Science Fiction" },
            new Book { Id = 2, Title = "1984", Author = "George Orwell", Genre = "Dystopian" },
            new Book { Id = 3, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Genre = "Fiction" },
            new Book { Id = 4, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Classic" },
            new Book { Id = 5, Title = "Pride and Prejudice", Author = "Jane Austen", Genre = "Romance" },
            new Book { Id = 6, Title = "Harry Potter", Author = "J.K. Rowling", Genre = "Fantasy"}
            });
        }
        public static BookService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BookService();
            }
            return _instance;
        }

        public List<Book> BuyBooks()
        {
            Console.WriteLine($"Welcome to our bookstore.");

            while (!UserWantsToExit())
            {
                DisplayAvailableBooks();
                BuyBook();
            }

            return ConfirmPurchase();
        }

        private bool UserWantsToExit()
        {
            Console.WriteLine("Press any key to add books. Press 'Esc' to exit.");
            return Console.ReadKey(true).Key == ConsoleKey.Escape;
        }

        private void DisplayAvailableBooks()
        {
            List<Book> availableBooks = _repository.GetAll();
            availableBooks.ForEach(book => Console.WriteLine(book));
        }

        private void BuyBook()
        {
            Console.WriteLine("Enter the ID of the book you want to buy:");

            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                Book forSale = SearchBook(id);

                if (forSale == null)
                {
                    Console.WriteLine("Book not found. Please enter a valid book ID.");
                    return;
                }

                RemoveBook(id);
                _booksForSale.Add(forSale);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid numeric book ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private List<Book> ConfirmPurchase()
        {
            Console.WriteLine("Would you like to save the list of purchased books? (Y/N)");
            string confirmation = Console.ReadLine().Trim().ToUpper();
           

                if (confirmation == "Y")
                {
                    Console.WriteLine("List of purchased books saved.");
                    return _booksForSale;
                }
                else
                {
                    Console.WriteLine("List of purchased books discarded.");
                    return new List<Book>();
                }
            
        }

        public Book SearchBook(int id)
        {
            Book? book = _repository.Get(id);

            if (book == null)
            {
                throw new ArgumentException($"Book with ID {id} not found.");
            }

            return book;
        }

        public void RemoveBook(int id)
        {
            if (_repository.Get(id) == null)
            {
                throw new ArgumentException($"Book with ID {id} not found.");
            }

            _repository.Delete(id);
        }
    }
}
