using System.Collections.Generic;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;

namespace Lab13_AsyncInn.Data.Repositories
{
    public interface IHotelRoomRepository
    {
        Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms(int hotelId);

        Task<HotelRoomDTO> GetOneHotelRoomById(int roomNumber, int hotelId);

        Task<bool> UpdateHotelRoom(int hotelId, HotelRoom hotelRoom);

        Task<HotelRoomDTO> AddHotelRoom(HotelRoom hotelRoom);
    }
}
