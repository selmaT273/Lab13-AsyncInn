using System;
using System.Collections.Generic;

namespace Lab13_AsyncInn.Models
{
    public class Amenities
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<RoomAmenities> RoomAmenities { get; set; }
    }
}
