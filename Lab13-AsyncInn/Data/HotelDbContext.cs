using Lab13_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;


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
                    new Hotel { Id = 1, Name = "Princess Royale" },
                    new Hotel { Id = 2, Name = "The Carousel" }
                );
        }

        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<HotelRoom> HotelRooms { get; set; }

        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomAmenities> RoomAmenities { get; set; }

        public DbSet<Amenities> Amenities { get; set; }
    }

    
}
