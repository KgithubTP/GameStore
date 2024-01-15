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
    public class DevelopersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

       // public DevelopersController(ApplicationDbContext context)
        public DevelopersController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Developers
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Developer>>> GetDevelopers()
        public async Task<IActionResult> GetDevelopers()
        {
            var developers = await _unitOfWork.Developers.GetAll();
            return Ok(developers);
        }

        // GET: api/Developers/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Developer>> GetDeveloper(int id)
        public async Task<IActionResult> GetDeveloper(int id)
        {
            var developer = await _unitOfWork.Developers.Get(q => q.Id == id);
            if (developer == null) 
            {
                return NotFound();
            }
            return Ok(developer);
        }

        // PUT: api/Developers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutDeveloper(int id, Developer developer)
        public async Task<IActionResult> PutDeveloper(int id, Developer developer)
        {
            if (id != developer.Id)
            {
                return BadRequest();
            }

            //_context.Entry(developer).State = EntityState.Modified;
            _unitOfWork.Developers.Update(developer);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!DeveloperExists(id))
                if (!await DeveloperExists(id))
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

        // POST: api/Developers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Developer>> PostDeveloper(Developer developer)
        {
            /*
          if (_context.Developers == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Developers'  is null.");
          }
            _context.Developers.Add(developer);
            await _context.SaveChangesAsync();
            */
            await _unitOfWork.Developers.Insert(developer);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetDeveloper", new { id = developer.Id }, developer);
        }

        // DELETE: api/Developers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeveloper(int id)
        {
            /* if (_context.Developers == null)
             {
                 return NotFound();
             }
             var developer = await _context.Developers.FindAsync(id); */

            var developer = await _unitOfWork.Developers.Get(q => q.Id == id);
            if (developer == null)
            {
                return NotFound();
            }

            //_context.Developers.Remove(developer);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Developers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool DeveloperExists(int id)
        private async Task<bool> DeveloperExists(int id)
        {
            //return (_context.Developers?.Any(e => e.Id == id)).GetValueOrDefault();
            var developer = await _unitOfWork.Developers.Get(q => q.Id == id);
            return developer != null;
        }
    }
}
