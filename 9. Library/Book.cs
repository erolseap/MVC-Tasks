namespace LibraryApp;

public class Book
{
    protected static int _idCounter = 0;

    public int Id { get; }
    public string Name { get; set; }
    public string AuthorName { get; set; }
    public decimal Price { get; set; }

    public Book(string name, string authorName, decimal price)
    {
        Id = ++_idCounter; // Auto-incrementing ID
        Name = name;
        AuthorName = authorName;
        Price = price;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"ID: {Id}, Name: {Name}, Author: {AuthorName}, Price: {Price}");
    }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Author: {AuthorName}, Price: {Price}";
    }
}
