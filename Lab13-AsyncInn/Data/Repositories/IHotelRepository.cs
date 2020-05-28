using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;

namespace Lab13_AsyncInn.Data.Repositories
{
    public interface IHotelRepository
    { 
        Task<IEnumerable<HotelDTO>> GetAllHotels();

        Task<HotelDTO> GetOneHotel(int id);

        Task<bool> UpdateHotel(int id, Hotel hotel);

        Task<Hotel> AddHotel(Hotel hotel);

        Task<Hotel> DeleteHotel(int id);
    }
}
