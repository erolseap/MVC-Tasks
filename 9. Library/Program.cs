namespace LibraryApp;

internal class Program
{
    static void Main(string[] args)
    {
        var library = new Library(RequireStringInput("Library name", 3));
        var doExit = false;
        do
        {
            switch(RequireIntInput( "Menu\n" +
                                    "1. Add book\n" +
                                    "2. Get book by id\n" +
                                    "3. Remove book\n" +
                                    "4. Update Book\n" +
                                    "5. Get all books\n" +
                                    "0. Quit"))
            {
                case 0: doExit = true; break;
                case 1:
                    {
                        var book = new Book(RequireStringInput("Name", 3), RequireStringInput("Author name", 3), RequireIntInput("Price", 0));
                        library.AddBook(book);
                        Console.WriteLine($"Added! Book id: {book.Id}");
                    }
                    break;
                case 2:
                    {
                        var book = library.GetBookById(RequireIntInput("Book id", 0));
                        if (book == null)
                        {
                            Console.WriteLine("Book does not exist");
                        }
                        else
                        {
                            book.ShowInfo();
                        }
                    }
                    break;
                case 3:
                    {
                        var id = RequireIntInput("Book id", 0);
                        var book = library.GetBookById(id);
                        if (book == null)
                        {
                            Console.WriteLine("Book does not exist");
                        }
                        else
                        {
                            library.RemoveBook(id);
                            Console.WriteLine("Removed!");
                        }
                    }
                    break;
                case 4:
                    {
                        var id = RequireIntInput("Book id", 0);
                        var existingBook = library.GetBookById(id);
                        if (existingBook == null)
                        {
                            Console.WriteLine("Book does not exist");
                        }
                        else
                        {
                            var book = new Book(RequireStringInput("Name", 3), RequireStringInput("Author name", 3), RequireIntInput("Price", 0));
                            library.Update(id, book);
                            Console.WriteLine("Updated!");
                        }
                    }
                    break;
                case 5:
                    {
                        library.GetAllBooks();
                    }
                    break;
            }
        } while (!doExit);
    }

    static int RequireIntInput(string? infoStr = null, int minValue = int.MinValue, int maxValue = int.MaxValue)
    {
        while (true)
        {
            if (infoStr != null && infoStr.Length != 0)
            {
                Console.Write(infoStr + ": ");
            }
            var input = Console.ReadLine();
            if (input != null)
            {
                try
                {
                    var res = int.Parse(input);
                    if (res >= minValue && res <= maxValue)
                    {
                        return res;
                    }
                    else
                    {
                        Console.WriteLine($"Minimum: {minValue}, maximum: {maxValue}");
                    }
                }
                catch
                {
                }
            }
        }
        return 0;
    }

    static string RequireStringInput(string? infoStr = null, uint minLength = uint.MinValue, uint maxLength = uint.MaxValue)
    {
        while (true)
        {
            if (infoStr != null && infoStr.Length != 0)
            {
                Console.Write(infoStr + ": ");
            }
            var input = Console.ReadLine();
            if (input != null)
            {
                if (input.Length >= minLength && input.Length <= maxLength)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine($"Minimum length: {minLength}, maximum length: {maxLength}");
                }
            }
        }
        return "";
    }
}
