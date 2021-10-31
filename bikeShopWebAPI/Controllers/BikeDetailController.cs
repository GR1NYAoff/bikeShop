using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using bikeShopWebAPI.Models;

namespace bikeShopWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BikeDetailController : ControllerBase
    {
        private readonly BikeDetailContext _context;

        public BikeDetailController(BikeDetailContext context)
        {
            _context = context;
        }

        // GET: api/BikeDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BikeDetail>>> GetBikeDetails()
        {
            return await _context.BikeDetails.ToListAsync();
        }

        // GET: api/BikeDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BikeDetail>> GetBikeDetail(int id)
        {
            var bikeDetail = await _context.BikeDetails.FindAsync(id);

            if (bikeDetail == null)
            {
                return NotFound();
            }

            return bikeDetail;
        }

        // PUT: api/BikeDetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBikeDetail(int id, [Bind("BikeRented")] BikeDetail bikeDetail)
        {
            if (id != bikeDetail.BikeID)
            {
                return BadRequest();
            }
           
            _context.BikeDetails.Attach(bikeDetail);
            _context.Entry(bikeDetail).Property(b => b.BikeRented).IsModified = true;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BikeDetail
        [HttpPost]
        public async Task<ActionResult<BikeDetail>> PostBikeDetail(BikeDetail bikeDetail)
        {
            _context.BikeDetails.Add(bikeDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBikeDetail", new { id = bikeDetail.BikeID }, bikeDetail);
        }

        // DELETE: api/BikeDetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBikeDetail(int id)
        {
            var bikeDetail = await _context.BikeDetails.FindAsync(id);
            if (bikeDetail == null)
            {
                return NotFound();
            }

            _context.BikeDetails.Remove(bikeDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BikeDetailExists(int id)
        {
            return _context.BikeDetails.Any(e => e.BikeID == id);
        }
    }
}
