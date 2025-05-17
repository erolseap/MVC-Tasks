namespace ConsoleApp6;

internal class Program
{
    static void Main(string[] args)
    {
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
