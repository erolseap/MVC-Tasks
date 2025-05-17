namespace ConsoleApp6;

public class CapacityLimitException : Exception
{
    public CapacityLimitException()
    {
        
    }

    public CapacityLimitException(string msg) : base(msg)
    {
    }
}
