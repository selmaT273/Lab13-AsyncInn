using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;

namespace Lab13_AsyncInn.Data.Repositories
{
    public interface IHotelRepository
    { 
        Task<IEnumerable<Hotel>> GetAllHotels();

        Task<Hotel> GetOneHotel(int id);

        Task<bool> UpdateHotel(int id, Hotel hotel);

        Task<Hotel> AddHotel(Hotel hotel);

        Task<Hotel> DeleteHotel(int id);
    }
}
