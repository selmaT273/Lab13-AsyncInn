using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;

namespace Lab13_AsyncInn.Data.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();

        Task<Room> GetOneRoom(int id);

        Task<bool> UpdateRoom(int id, Room room);

        Task<Room> AddRoom(Room room);

        Task<Room> DeleteRoom(int id);
    }
}
