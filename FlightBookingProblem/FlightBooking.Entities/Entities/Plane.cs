using FlightBooking.Entities;
using System.Collections.Generic;

namespace FlightBooking.Entities.Models
{
    public class Plane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfSeats { get; set; }
    }

    public static class PlanesList
    {
        public static List<Plane> Planes 
            => new List<Plane>(new[] 
            { 
                new Plane() { Id = 123, Name = "Antonov AN-2", NumberOfSeats = 12 },
                new Plane() { Id = 456, Name = "Bombardier Q400", NumberOfSeats = 14 },
                new Plane() { Id = 789, Name = "ATR 640", NumberOfSeats = 16 },
            });
    }
}
