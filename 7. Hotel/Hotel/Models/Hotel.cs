using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelTask.Models;

class Hotel
{
    protected static uint _uidCounter = 0;

    public uint Id { get; }
    public string Name { get; set; }
    public List<Room> Rooms { get; } = [];

    public Hotel(string name)
    {
        Name = name;
    }

    public void AddRoom(Room room)
    {
        Rooms.Add(room);
    }

    public List<Room> GetRooms()
    {
        return Rooms;
    }

    public List<Room> GetAvailableRooms()
    {
        List<Room> rooms = [];
        foreach (var room in Rooms)
        {
            if (room.IsAvailable)
            {
                rooms.Add(room);
            }            
        }
        return rooms;
    }

    public List<Room> GetRoomsByCapacity(uint capacity)
    {
        List<Room> rooms = [];
        foreach (var room in Rooms)
        {
            if (room.PersonCapacity == capacity)
            {
                rooms.Add(room);
            }
        }
        return rooms;
    }

    public Room? GetRoomById(uint id)
    {
        foreach (var room in Rooms)
        {
            if (room.Id == id)
            {
                return room;
            }
        }
        return null;
    }

    public void MakeReservation(uint roomId)
    {
        var room = GetRoomById(roomId);
        if (room != null)
        {
            if (room.Reserve())
            {
                Console.WriteLine("Room reserved successfully");
            }
            else
            {
                Console.WriteLine("Room is full");
            }
        }
        else
        {
            Console.WriteLine("Room does not exist");
        }
    }
}
