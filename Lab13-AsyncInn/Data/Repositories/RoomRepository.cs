using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
using Microsoft.EntityFrameworkCore;

namespace Lab13_AsyncInn.Data.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelDbContext _context;

        public RoomRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomDTO>> GetAllRooms()
        {
            var rooms = await _context.Rooms
                .Select(room => new RoomDTO
                {
                    ID = room.Id,
                    Name = room.Name,
                    Layout = room.Layout.ToString(),

                    Amenities = room.Amenities
                        .Select(ra => new AmenitiesDTO
                        {
                            ID = ra.Amenities.Id,
                            Name = ra.Amenities.Name,
                        })
                        .ToList()
                })
                .ToListAsync();

            return rooms;
        }

        public async Task<Room> GetOneRoom(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<bool> UpdateRoom(int id, Room room)
        {
            _context.Entry(room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }

        public async Task<Room> AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<Room> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return null;
            }

            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task AddAmenityToRoom(int amenityId, int roomId) 
        {
            var roomAmenity = new RoomAmenities
            {
                AmenitiesId = amenityId,
                RoomId = roomId,
            };
            _context.RoomAmenities.Add(roomAmenity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAmenityFromRoom(int amenityId, int roomId)
        {
            var roomAmenity = await _context.RoomAmenities
                .Where(ra => ra.AmenitiesId == amenityId)
                .Where(ra => ra.RoomId == roomId)
                .FirstOrDefaultAsync();
            
            if (roomAmenity != null)
            {
                _context.RoomAmenities.Remove(roomAmenity);
                await _context.SaveChangesAsync(); 
            } 
        }
    }
}
