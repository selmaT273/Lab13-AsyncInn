using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;

namespace Lab13_AsyncInn.Data.Repositories
{
    public interface IAmenitiesRepository
    {
        Task<IEnumerable<Amenities>> GetAllAmenities();

        Task<Amenities> GetOneAmenities(int id);

        Task<bool> UpdateAmenities(int id, Amenities amenities);

        Task<Amenities> AddAmenities(Amenities amenities);

        Task<Amenities> DeleteAmenities(int id);
    }
}
