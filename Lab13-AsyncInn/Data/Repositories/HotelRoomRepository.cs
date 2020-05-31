using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
using Microsoft.EntityFrameworkCore;

namespace Lab13_AsyncInn.Data.Repositories
{
    public class HotelRoomRepository : IHotelRoomRepository 
    {
        private readonly HotelDbContext _context;

        public HotelRoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public Task<HotelRoomDTO> AddHotelRoom(HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<HotelRoomDTO>> GetAllHotelRooms(int hotelId)
        {
            var hotelRoom = await _context.HotelRooms
            .Select(r => new HotelRoomDTO
            {
                 HotelId = r.HotelId,
                 Room = new RoomDTO
                 {
                     ID = r.Room.Id,
                     Name = r.Room.Name,
                     Layout = r.Room.Layout.ToString(),
                     Amenities = r.Room.Amenities
                        .Select(a => new AmenitiesDTO
                        {
                            ID = a.Amenities.Id,
                            Name = a.Amenities.Name

                        })
                        .ToList()
                 },

             })
            .ToListAsync();

            return hotelRoom;

        }

        public Task<HotelRoomDTO> GetOneHotelRoomById(int roomNumber, int hotelId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateHotelRoom(int hotelId, HotelRoom hotelRoom)
        {
            throw new NotImplementedException();
        }
    }
}
