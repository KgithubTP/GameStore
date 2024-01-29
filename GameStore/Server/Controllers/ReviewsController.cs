﻿using System;
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
    public class ReviewsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        // public ReviewsController(ApplicationDbContext context)
        public ReviewsController(IUnitOfWork unitOfWork)
        {
            // _context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Reviews
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<Review>>> GetReviews()
        public async Task<IActionResult> GetReviews()
        {
            var Reviews = await _unitOfWork.Reviews.GetAll();
            return Ok(Reviews);
        }

        // GET: api/Reviews/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Review>> GetReview(int id)
        public async Task<IActionResult> GetReview(int id)
        {
            var Review = await _unitOfWork.Reviews.Get(q => q.Id == id);
            if (Review == null)
            {
                return NotFound();
            }
            return Ok(Review);
        }

        // PUT: api/Reviews/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutReview(int id, Review Review)
        public async Task<IActionResult> PutReview(int id, Review Review)
        {
            if (id != Review.Id)
            {
                return BadRequest();
            }

            //_context.Entry(Review).State = EntityState.Modified;
            _unitOfWork.Reviews.Update(Review);

            try
            {
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!ReviewExists(id))
                if (!await ReviewExists(id))
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

        // POST: api/Reviews
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Review>> PostReview(Review Review)
        {
            /*
          if (_context.Reviews == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Reviews'  is null.");
          }
            _context.Reviews.Add(Review);
            await _context.SaveChangesAsync();
            */
            await _unitOfWork.Reviews.Insert(Review);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetReview", new { id = Review.Id }, Review);
        }

        // DELETE: api/Reviews/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            /* if (_context.Reviews == null)
             {
                 return NotFound();
             }
             var Review = await _context.Reviews.FindAsync(id); */

            var Review = await _unitOfWork.Reviews.Get(q => q.Id == id);
            if (Review == null)
            {
                return NotFound();
            }

            //_context.Reviews.Remove(Review);
            //await _context.SaveChangesAsync();

            await _unitOfWork.Reviews.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //private bool ReviewExists(int id)
        private async Task<bool> ReviewExists(int id)
        {
            //return (_context.Reviews?.Any(e => e.Id == id)).GetValueOrDefault();
            var Review = await _unitOfWork.Reviews.Get(q => q.Id == id);
            return Review != null;
        }
    }
}
