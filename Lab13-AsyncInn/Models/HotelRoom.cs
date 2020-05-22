﻿using System;
namespace Lab13_AsyncInn.Models
{
    public class HotelRoom
    {
        public int HotelId { get; set; }

        public int RoomNumber { get; set; }

        public int RoomId { get; set; }

        public decimal Rate { get; set; }

        public bool PetFriendly { get; set; }

        public Hotel Hotel { get; set; }

        public Room Room { get; set; }
    }
}