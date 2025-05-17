namespace ConsoleApp6;

public class Department
{
    public string Name { get; set; }
    public uint EmployeeLimit { get; set; }
    public Employee[] Employees { get => _employees; }

    protected Employee[] _employees = [];

    public Department(string name, uint employeeLimit)
    {
        Name = name;
        EmployeeLimit = employeeLimit;
    }

    public void AddEmployee(Employee employee)
    {
        if (EmployeeLimit < _employees.Length + 1)
        {
            throw new CapacityLimitException();
        }

        Array.Resize(ref _employees, _employees.Length + 1);
        _employees[^1] = employee;
    }

    public Employee this[uint idx]
    {
        get => _employees[idx];
        set => _employees[idx] = value;
    }
}
