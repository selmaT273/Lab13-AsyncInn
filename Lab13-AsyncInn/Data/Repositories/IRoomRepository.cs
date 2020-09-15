using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;

namespace Lab13_AsyncInn.Data.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomDTO>> GetAllRooms();

        Task<Room> GetOneRoom(int id);

        Task<bool> UpdateRoom(int id, Room room);

        Task<Room> AddRoom(Room room);

        Task<Room> DeleteRoom(int id);

        Task AddAmenityToRoom(int amenityId, int roomId);

        Task RemoveAmenityFromRoom(int roomId, int amenityId);
    }
}
