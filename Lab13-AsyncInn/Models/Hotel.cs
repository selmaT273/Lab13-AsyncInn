﻿using System;
using System.Linq;

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Lab13_AsyncInn.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string StreetAddress { get; set; }

        public string City { get; set; }

        [Required]
        public string State { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public List<HotelRoom> HotelRoom { get; set; }

    }
}
