using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab13_AsyncInn.Data.Repositories
{
    public class AmenitiesRepository : IAmenitiesRepository
    {
        private readonly HotelDbContext _context;

        public AmenitiesRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Amenities>> GetAllAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        public async Task<Amenities> GetOneAmenities(int id)
        {
            return await _context.Amenities.FindAsync(id);
        }

        public async Task<bool> UpdateAmenities(int id, Amenities amenities)
        {
            _context.Entry(amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenitiesExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool AmenitiesExists(int id)
        {
            return _context.Amenities.Any(e => e.Id == id);
        }

        public async Task<Amenities> AddAmenities(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();
            return amenities;
        }

        public async Task<Amenities> DeleteAmenities(int id)
        {
            var amenities = await _context.Amenities.FindAsync(id);
            if (amenities == null)
            {
                return null;
            }

            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();

            return amenities;
        }
    }
}
