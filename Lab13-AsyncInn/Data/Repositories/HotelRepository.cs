using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab13_AsyncInn.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hotel>> GetAllHotels()
        {
            return await _context.Hotel.ToListAsync();
        }

        public async Task<Hotel> GetOneHotel(int id)
        {
            return await _context.Hotel.FindAsync(id);
        }

        public async Task<bool> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.Id == id);
        }

        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<Hotel> DeleteHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return null;
            }

            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }

    }
}
