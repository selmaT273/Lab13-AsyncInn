﻿using System;
using System.Linq;
namespace Lab13_AsyncInn.Models.Api
{
    public class HotelRoomDTO
    {
        public int HotelId { get; set; }
        public int RoomNumber { get; set; }
        public decimal Rate { get; set; }
        public bool PetFriendly { get; set; }
        public int RoomID { get; set; }
        public RoomDTO Room { get; set; }
    }
}
