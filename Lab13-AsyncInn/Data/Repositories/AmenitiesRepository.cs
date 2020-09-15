using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
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

        public async Task<IEnumerable<AmenitiesDTO>> GetAllAmenities()
        {
            var amenities = await _context.Amenities
                .Select(amenity => new AmenitiesDTO
                {
                    ID = amenity.Id,
                    Name = amenity.Name,
                })
                .ToListAsync();

            return amenities;
        }

        public async Task<AmenitiesDTO> GetOneAmenities(int amenitiesId)
        {
            var amenities = await _context.Amenities
                .Select(amenity => new AmenitiesDTO
                {
                    ID = amenity.Id,
                    Name = amenity.Name,
                })
                .FirstOrDefaultAsync(amenity => amenity.ID == amenitiesId);

            return amenities;
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
