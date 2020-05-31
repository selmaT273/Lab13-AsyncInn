using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab13_AsyncInn.Models.Api
{
    public class RoomDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Layout { get; set; }
        public List<AmenitiesDTO> Amenities { get; set; }
    }
}
