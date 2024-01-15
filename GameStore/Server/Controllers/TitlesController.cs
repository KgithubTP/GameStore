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
    public class TitlesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public TitlesController(ApplicationDbContext context)
        public TitlesController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Titles
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Title>>> GetTitles()
        public async Task<IActionResult> GetTitles()
        {
            var Titles = await _unitOfWork.Titles.GetAll();
            return Ok(Titles);
        }

        // GET: api/Titles/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Title>> GetTitle(int id)
        public async Task<IActionResult> GetTitle(int id)
        {
            var Title = await _unitOfWork.Titles.Get(q => q.Id == id);
            if (Title == null)
            {
                return NotFound();
            }
            return Ok(Title);
        }

        // PUT: api/Titles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutTitle(int id, Title Title)
        public async Task<IActionResult> PutTitle(int id, Title Title)
        {
            if (id != Title.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Title).State = EntityState.Modified;
            _unitOfWork.Titles.Update(Title);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!TitleExists(id))
                if (!await TitleExists(id))
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

        // POST: api/Titles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Title>> PostTitle(Title Title)
        {
            /*
          if (_context.Titles == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Titles'  is null.");
          }
            _context.Titles.Add(Title);
            await _context.SaveChangesAsync();
            */
            await _unitOfWork.Titles.Insert(Title);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetTitle", new { id = Title.Id }, Title);
        }

        // DELETE: api/Titles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTitle(int id)
        {
            /* if (_context.Titles == null)
             {
                 return NotFound();
             }
             var Title = await _context.Titles.FindAsync(id); */

            var Title = await _unitOfWork.Titles.Get(q => q.Id == id);
            if (Title == null)
            {
                return NotFound();
            }

            //_context.Titles.Remove(Title);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Titles.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool TitleExists(int id)
        private async Task<bool> TitleExists(int id)
        {
            //return (_context.Titles?.Any(e => e.Id == id)).GetValueOrDefault();
            var Title = await _unitOfWork.Titles.Get(q => q.Id == id);
            return Title != null;
        }
    }
}
