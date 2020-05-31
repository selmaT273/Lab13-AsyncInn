using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
using Microsoft.EntityFrameworkCore;

namespace Lab13_AsyncInn.Data.Repositories
{
    public class HotelRepository : IHotelRepository
    {
        private readonly HotelDbContext _context;

        public HotelRepository(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<HotelDTO>> GetAllHotels()
        {
            var hotels = await _context.Hotel
                .Select(hotel => new HotelDTO
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAddress,
                    City = hotel.City,
                    Phone = hotel.Phone,
                    Room = hotel.HotelRoom
                        .Select(r => new HotelRoomDTO
                        {
                            HotelId = r.HotelId,
                            RoomNumber = r.RoomNumber,
                            Rate = r.Rate,
                            PetFriendly = r.PetFriendly,
                            RoomID = r.RoomId,
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
                        .ToList(),
                })

                .ToListAsync();

            return hotels;
        }

        public async Task<HotelDTO> GetOneHotel(int id)
        {
            var hotel = await _context.Hotel
                .Select(hotel => new HotelDTO
                {
                    ID = hotel.Id,
                    Name = hotel.Name,
                    StreetAddress = hotel.StreetAddress,
                    City = hotel.City,
                    Phone = hotel.Phone,
                    Room = hotel.HotelRoom
                        .Select(r => new HotelRoomDTO
                        {
                            HotelId = r.HotelId,
                            RoomNumber = r.RoomNumber,
                            Rate = r.Rate,
                            PetFriendly = r.PetFriendly,
                            RoomID = r.RoomId,
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
                        .ToList(),
                })
                .FirstOrDefaultAsync(hotel => hotel.ID == id);


            return hotel;

        }

        public async Task<bool> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HotelExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
        }

        private bool HotelExists(int id)
        {
            return _context.Hotel.Any(e => e.Id == id);
        }

        public async Task<HotelDTO> AddHotel(Hotel hotel)
        {
            _context.Hotel.Add(hotel);
            await _context.SaveChangesAsync();
            return await GetOneHotel(hotel.Id);
        }

        public async Task<Hotel> DeleteHotel(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            if (hotel == null)
            {
                return null;
            }

            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();

            return hotel;
        }

    }
}
