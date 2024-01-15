using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.Server.Data;
using GameStore.Shared.Domain;
using GameStore.Server.IRepository;

namespace GameStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public PlatformsController(ApplicationDbContext context)
        public PlatformsController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Platforms
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Platform>>> GetPlatforms()
        public async Task<IActionResult> GetPlatforms()
        {
            var Platforms = await _unitOfWork.Platforms.GetAll();
            return Ok(Platforms);
        }

        // GET: api/Platforms/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Platform>> GetPlatform(int id)
        public async Task<IActionResult> GetPlatform(int id)
        {
            var Platform = await _unitOfWork.Platforms.Get(q => q.Id == id);
            if (Platform == null)
            {
                return NotFound();
            }
            return Ok(Platform);
        }

        // PUT: api/Platforms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutPlatform(int id, Platform Platform)
        public async Task<IActionResult> PutPlatform(int id, Platform Platform)
        {
            if (id != Platform.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Platform).State = EntityState.Modified;
            _unitOfWork.Platforms.Update(Platform);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!PlatformExists(id))
                if (!await PlatformExists(id))
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

        // POST: api/Platforms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Platform>> PostPlatform(Platform Platform)
        {
            /*
          if (_context.Platforms == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Platforms'  is null.");
          }
            _context.Platforms.Add(Platform);
            await _context.SaveChangesAsync();
            */
            await _unitOfWork.Platforms.Insert(Platform);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetPlatform", new { id = Platform.Id }, Platform);
        }

        // DELETE: api/Platforms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlatform(int id)
        {
            /* if (_context.Platforms == null)
             {
                 return NotFound();
             }
             var Platform = await _context.Platforms.FindAsync(id); */

            var Platform = await _unitOfWork.Platforms.Get(q => q.Id == id);
            if (Platform == null)
            {
                return NotFound();
            }

            //_context.Platforms.Remove(Platform);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Platforms.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool PlatformExists(int id)
        private async Task<bool> PlatformExists(int id)
        {
            //return (_context.Platforms?.Any(e => e.Id == id)).GetValueOrDefault();
            var Platform = await _unitOfWork.Platforms.Get(q => q.Id == id);
            return Platform != null;
        }
    }
}
