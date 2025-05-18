using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp;

public class Library
{
    public string Name { get; set; }
    private List<Book> Books { get; set; }

    public Library(string name)
    {
        Name = name;
        Books = [];
    }

    public void AddBook(Book book)
    {
        Books.Add(book);
        Console.WriteLine($"Book {book.Name} added");
    }

    public Book? GetBookById(int id)
    {
        Book? book = Books.FirstOrDefault(b => b.Id == id);
        return book;
    }

    public void RemoveBook(int id)
    {
        Book? book = GetBookById(id);
        if (book == null) return;
        Books.Remove(book);
    }

    public List<Book> GetBook(string name)
    {
        return Books.Where(b => b.Name.Equals(name)).ToList();
    }

    public void GetAllBooks()
    {
        Console.WriteLine("Books list:");
        foreach (var book in Books)
        {
            book.ShowInfo();
        }
        Console.WriteLine("-----------------");
    }

    public void Update(int id, Book newBookData)
    {
        var book = GetBookById(id);
        if (book != null)
        {
            book.Name = newBookData.Name;
            book.AuthorName = newBookData.AuthorName;
            book.Price = newBookData.Price;
        }
    }
}
