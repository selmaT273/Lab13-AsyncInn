using System;
namespace Lab13_AsyncInn.Models
{
    public class Room
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Layout { get; set; }

        public Amenities Amenities { get; set; }

    }
}
