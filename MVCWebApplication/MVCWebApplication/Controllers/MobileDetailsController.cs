using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCWebApplication.Models;

namespace MVCWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobileDetailsController : ControllerBase
    {
        private readonly MobileDbContext _context;

        public MobileDetailsController(MobileDbContext context)
        {
            _context = context;
        }

        // GET: api/MobileDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobileDetail>>> GetMobileDetails()
        {
          if (_context.MobileDetails == null)
          {
              return NotFound();
          }
            return await _context.MobileDetails.ToListAsync();
        }

        // GET: api/MobileDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MobileDetail>> GetMobileDetail(int id)
        {
          if (_context.MobileDetails == null)
          {
              return NotFound();
          }
            var mobileDetail = await _context.MobileDetails.FindAsync(id);

            if (mobileDetail == null)
            {
                return NotFound();
            }

            return mobileDetail;
        }

        // PUT: api/MobileDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobileDetail(int id, MobileDetail mobileDetail)
        {
            if (id != mobileDetail.Id)
            {
                return BadRequest();
            }

            _context.Entry(mobileDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileDetailExists(id))
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

        // POST: api/MobileDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MobileDetail>> PostMobileDetail(MobileDetail mobileDetail)
        {
          if (_context.MobileDetails == null)
          {
              return Problem("Entity set 'MobileDbContext.MobileDetails'  is null.");
          }
            _context.MobileDetails.Add(mobileDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobileDetail", new { id = mobileDetail.Id }, mobileDetail);
        }

        // DELETE: api/MobileDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMobileDetail(int id)
        {
            if (_context.MobileDetails == null)
            {
                return NotFound();
            }
            var mobileDetail = await _context.MobileDetails.FindAsync(id);
            if (mobileDetail == null)
            {
                return NotFound();
            }

            _context.MobileDetails.Remove(mobileDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MobileDetailExists(int id)
        {
            return (_context.MobileDetails?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
