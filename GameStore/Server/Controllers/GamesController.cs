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
    public class GamesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public GamesController(ApplicationDbContext context)
        public GamesController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Games
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Game>>> GetGames()
        public async Task<IActionResult> GetGames()
        {
            var Games = await _unitOfWork.Games.GetAll(includes: q => q.Include(x =>x.Title).Include(x => x.Genre).Include(x => x.Platform).Include(x => x.Developer));
            return Ok(Games);
        }

        // GET: api/Games/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Game>> GetGame(int id)
        public async Task<IActionResult> GetGame(int id)
        {
            var Game = await _unitOfWork.Games.Get(q => q.Id == id);
            if (Game == null)
            {
                return NotFound();
            }
            return Ok(Game);
        }

        // PUT: api/Games/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutGame(int id, Game Game)
        public async Task<IActionResult> PutGame(int id, Game Game)
        {
            if (id != Game.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Game).State = EntityState.Modified;
            _unitOfWork.Games.Update(Game);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!GameExists(id))
                if (!await GameExists(id))
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

        // POST: api/Games
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Game>> PostGame(Game Game)
        {
            /*
          if (_context.Games == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Games'  is null.");
          }
            _context.Games.Add(Game);
            await _context.SaveChangesAsync();
            */
            await _unitOfWork.Games.Insert(Game);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetGame", new { id = Game.Id }, Game);
        }

        // DELETE: api/Games/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGame(int id)
        {
            /* if (_context.Games == null)
             {
                 return NotFound();
             }
             var Game = await _context.Games.FindAsync(id); */

            var Game = await _unitOfWork.Games.Get(q => q.Id == id);
            if (Game == null)
            {
                return NotFound();
            }

            //_context.Games.Remove(Game);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Games.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool GameExists(int id)
        private async Task<bool> GameExists(int id)
        {
            //return (_context.Games?.Any(e => e.Id == id)).GetValueOrDefault();
            var Game = await _unitOfWork.Games.Get(q => q.Id == id);
            return Game != null;
        }
    }
}
