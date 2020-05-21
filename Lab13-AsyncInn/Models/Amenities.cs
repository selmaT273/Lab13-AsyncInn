using System;
namespace Lab13_AsyncInn.Models
{
    public class Amenities
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public RoomAmenities RoomAmenities { get; set; }
    }
}
