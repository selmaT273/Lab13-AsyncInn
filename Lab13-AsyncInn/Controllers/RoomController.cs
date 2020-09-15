using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab13_AsyncInn.Data;
using Lab13_AsyncInn.Models;
using Lab13_AsyncInn.Data.Repositories;
using Lab13_AsyncInn.Models.Api;

namespace Lab13_AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IRoomRepository roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            this.roomRepository = roomRepository;
        }

        // GET: api/Room
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return Ok(await roomRepository.GetAllRooms());
        }

        // GET: api/Room/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            var room = await roomRepository.GetOneRoom(id);

            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        // PUT: api/Room/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            if (id != room.Id)
            {
                return BadRequest();
            }

            bool UpdateRoom = await roomRepository.UpdateRoom(id, room);

            if (!RoomExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Room
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            await roomRepository.AddRoom(room);

            return CreatedAtAction("GetRoom", new { id = room.Id }, room);
        }

        // DELETE: api/Room/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Room>> DeleteRoom(int id)
        {
            var room = await roomRepository.DeleteRoom(id);
            if (room == null)
            {
                return NotFound();
            }

            return room;
        }

        private bool RoomExists(int id)
        {
            return false;
        }

        // POST: api/Rooms/5/Amenities/3
        [HttpPost("{roomId}/Amenities/{amenityId}")]
        public async Task<ActionResult> AddRoomAmenity(int roomId, int amenityId)
        {
            await roomRepository.AddAmenityToRoom(amenityId, roomId);
            return NoContent();
        }

        // DELETE: api/Rooms/2/Amenities/3
        [HttpDelete("{roomId}/Amenities/{amenityId}")]
        public async Task<ActionResult> RemoveRoomAmenity(int roomId, int amenityId)
        {
            await roomRepository.RemoveAmenityFromRoom(amenityId, roomId);
            return NoContent(); 
        }

    }
}
