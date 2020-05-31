using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Models.Api;
using Lab13_AsyncInn.Data.Repositories;

namespace Lab13_AsyncInn.Controllers
{
    [Route("api/Hotels")]
    [ApiController]
    public class HotelRoomController : ControllerBase
    {
        IHotelRoomRepository hotelRoomRepository;

        public HotelRoomController(IHotelRoomRepository hotelRoomRepository)
        {
            this.hotelRoomRepository = hotelRoomRepository;
        }

        // GET: api/HotelRoom
        [HttpGet("{hotelId}/Rooms")]
        public async Task<ActionResult<IEnumerable<HotelRoomDTO>>> GetAllHotelRooms(int hotelId)
        {
            return Ok(await hotelRoomRepository.GetAllHotelRooms(hotelId));
        }

        // GET: api/HotelRoom/5
        [HttpGet("{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoomDTO>> GetOneHotelRoomById(int roomNumber, int hotelId)
        {
            var hotelRoom = await hotelRoomRepository.GetOneHotelRoomById(roomNumber, hotelId);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRoom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int roomNumber, HotelRoom hotelRoom)
        {
            if (roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            bool roomUpdated = await hotelRoomRepository.UpdateHotelRoom(roomNumber, hotelRoom);

           if (!roomUpdated)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/HotelRoom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom)
        {
            var hotelRoomAdded = await hotelRoomRepository.AddHotelRoom(hotelRoom);

            return CreatedAtAction("GetHotelRoom", new { hotelRoomAdded.HotelId, hotelRoomAdded.RoomNumber }, hotelRoomAdded);
        }

        
    }
}
