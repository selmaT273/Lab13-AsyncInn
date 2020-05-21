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

        public DbSet<Hotel> Hotel { get; set; }
    }

    
}
