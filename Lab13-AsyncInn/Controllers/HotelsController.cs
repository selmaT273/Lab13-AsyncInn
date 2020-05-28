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
    [Route("api/Hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        IHotelRepository hotelRepository;

        public HotelsController(IHotelRepository hotelRepository)
        {
            this.hotelRepository = hotelRepository;
        }

        // GET: api/Hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotel()
        {
            return Ok(await hotelRepository.GetAllHotels());
        }

        // GET: api/Hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelDTO>> GetHotel(int id)
        {
            var hotel = await hotelRepository.GetOneHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }

            return hotel;
        }

        // PUT: api/Hotels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotel(int id, Hotel hotel)
        {
            if (id != hotel.Id)
            {
                return BadRequest();
            }

            bool UpdateHotel = await hotelRepository.UpdateHotel(id, hotel);

            if (!UpdateHotel)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Hotels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotel(Hotel hotel)
        {
            await hotelRepository.AddHotel(hotel);

            return CreatedAtAction("GetHotel", new { id = hotel.Id }, hotel);
        }

        // DELETE: api/Hotels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Hotel>> DeleteHotel(int id)
        {
            var hotel = await hotelRepository.DeleteHotel(id);

            if (hotel == null)
            {
                return NotFound();
            }


            return hotel;
        }

        private bool HotelExists(int id)
        {
            return false;
        }
    }
}
