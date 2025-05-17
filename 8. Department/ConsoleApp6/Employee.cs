namespace ConsoleApp6;

public class Employee : IPerson
{
    public required string Name { get; set; }
    public required byte Age { get; set; }
    public required uint Salary { get; set; }

    public Employee(string name, byte age, uint salary)
    {
        Name = name;
        Age = age;
        Salary = salary;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"{Name} {Age} {Salary}");
    }
}
