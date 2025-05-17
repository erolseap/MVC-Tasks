using HotelTask.Models;

var hotel = new Hotel(RequireStringInput("Hotel name", 3));

var doExit = false;
do
{
    Console.WriteLine("-----------------------------------------");
    switch (RequireIntInput("1. Create a room\n" +
                            "2. Add room\n" +
                            "3. Make reserve\n" +
                            "0. Exit\n" +
                            "\n" +
                            "Sizin secim", 0, 3))
    {
        case 0: doExit = true; break;
        case 1:
            {
                var createdRoom = new Room(RequireStringInput("Name", 1), RequireIntInput("Price", 0), (uint)RequireIntInput("Capacity", 1));
                hotel.AddRoom(createdRoom);
                Console.WriteLine("Room id: " + createdRoom.Id);
            }
            break;
        case 2:
            {
                hotel.MakeReservation((uint)RequireIntInput("Room id", 1));
            }
            break;
    }
} while (!doExit);

int RequireIntInput(string? infoStr = null, int minValue = int.MinValue, int maxValue = int.MaxValue)
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

string RequireStringInput(string? infoStr = null, uint minLength = uint.MinValue, uint maxLength = uint.MaxValue)
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