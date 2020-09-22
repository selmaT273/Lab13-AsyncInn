using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;

namespace Lab13_AsyncInn.Data.Repositories
{
    public interface IAmenitiesRepository
    {
        Task<IEnumerable<AmenitiesDTO>> GetAllAmenities();

        Task<AmenitiesDTO> GetOneAmenities(int amenitiesId);

        Task<bool> UpdateAmenities(int id, Amenities amenities);

        Task<Amenities> AddAmenities(Amenities amenities);

        Task<Amenities> DeleteAmenities(int id);
    }
}
