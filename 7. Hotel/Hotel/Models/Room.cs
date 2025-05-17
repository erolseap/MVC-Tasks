using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Models;

class Room
{
    protected static uint _uidCounter = 0;

    public uint Id { get; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public uint PersonCapacity { get; }
    public bool IsAvailable { get => !_isReserved; }
    protected bool _isReserved = false;

    public Room(string name, decimal price, uint personCapacity)
    {
        Id = ++_uidCounter;
    }

    public override string ToString()
    {
        return $"{Name} {Price} {PersonCapacity}";
    }

    public bool Reserve()
    {
        if (!IsAvailable)
        {
            return false;
        }
        _isReserved = true;
        return true;
    }
}
