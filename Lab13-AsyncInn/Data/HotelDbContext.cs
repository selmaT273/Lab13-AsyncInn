using System;
using Lab13_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;


namespace Lab13_AsyncInn.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HotelRoom>()
                .HasKey(hotelRoom => new
                {
                    hotelRoom.HotelId,
                    hotelRoom.RoomId,
                });

            modelBuilder.Entity<RoomAmenities>()
                .HasKey(roomAmenities => new
                {
                    roomAmenities.RoomId,
                    roomAmenities.AmenitiesId,
                });

            modelBuilder.Entity<Hotel>()
                .HasData(
                    new Hotel { Id = 1, Name = "Princess Royale", State = "Maryland"},
                    new Hotel { Id = 2, Name = "The Carousel", State = "Maryland" }
                );

            modelBuilder.Entity<Room>()
                .HasData(
                    new Room { Id = 1, Name = "Single Seashell", Layout = RoomLayout.Single },
                    new Room { Id = 2, Name = "Single Starfish", Layout = RoomLayout.Single },
                    new Room { Id = 3, Name = "Double Turtle", Layout = RoomLayout.Double },
                    new Room { Id = 4, Name = "Triple Hit", Layout = RoomLayout.Triple },
                    new Room { Id = 5, Name = "Four Coral", Layout = RoomLayout.Quad },
                    new Room { Id = 6, Name = "Five's Company", Layout = RoomLayout.Quint }

                );
            modelBuilder.Entity<Amenities>()
                .HasData(
                    new Amenities { Id = 1, Name = "jacuzzi"},
                    new Amenities { Id = 2, Name = "ocean front view"},
                    new Amenities { Id = 3, Name = "bay view"}
                );

            modelBuilder.Entity<RoomAmenities>()
                .HasData(
                    new RoomAmenities { RoomId = 1, AmenitiesId = 1 },
                    new RoomAmenities { RoomId = 1, AmenitiesId = 2 },
                    new RoomAmenities { RoomId = 2, AmenitiesId = 3 },
                    new RoomAmenities { RoomId = 3, AmenitiesId = 2 },
                    new RoomAmenities { RoomId = 4, AmenitiesId = 1 },
                    new RoomAmenities { RoomId = 5, AmenitiesId = 3 },
                    new RoomAmenities { RoomId = 6, AmenitiesId = 1 }

                );
            modelBuilder.Entity<HotelRoom>()
                .HasData(
                    new HotelRoom { HotelId = 1, RoomNumber = 331, Rate = 50, PetFriendly = true, RoomId = 1 }
                );
        }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }

        public DbSet<Amenities> Amenities { get; set; }

    }

    
}
