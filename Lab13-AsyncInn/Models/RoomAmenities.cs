using System;
namespace Lab13_AsyncInn.Models
{
    public class RoomAmenities
    {
        public int AmenitiesId { get; set; }

        public int RoomId { get; set; }

        public Amenities Amenities { get; set; }

        public Room Room { get; set; }
    }
}
