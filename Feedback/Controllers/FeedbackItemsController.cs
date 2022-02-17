using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Feedback.Models;

namespace Feedback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackItemsController : ControllerBase
    {
        private readonly FeedbackContext _context;

        public FeedbackItemsController(FeedbackContext context)
        {
            _context = context;
        }

        // GET: api/FeedbackItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FeedbackItem>>> GetFeedbackItems()
        {
            return await _context.FeedbackItems.ToListAsync();
        }

        // GET: api/FeedbackItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FeedbackItem>> GetFeedbackItem(long id)
        {
            var feedbackItem = await _context.FeedbackItems.FindAsync(id);

            if (feedbackItem == null)
            {
                return NotFound();
            }

            return feedbackItem;
        }

        // PUT: api/FeedbackItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFeedbackItem(long id, FeedbackItem feedbackItem)
        {
            if (id != feedbackItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(feedbackItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FeedbackItemExists(id))
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

        // POST: api/FeedbackItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FeedbackItem>> PostFeedbackItem(FeedbackItem feedbackItem)
        {
            _context.FeedbackItems.Add(feedbackItem);
            await _context.SaveChangesAsync();

            // return CreatedAtAction("GetFeedbackItem", new { id = feedbackItem.Id }, feedbackItem);
            return CreatedAtAction(nameof(GetFeedbackItem), new { id = feedbackItem.Id }, feedbackItem);
        }

        // DELETE: api/FeedbackItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FeedbackItem>> DeleteFeedbackItem(long id)
        {
            var feedbackItem = await _context.FeedbackItems.FindAsync(id);
            if (feedbackItem == null)
            {
                return NotFound();
            }

            _context.FeedbackItems.Remove(feedbackItem);
            await _context.SaveChangesAsync();

            return feedbackItem;
        }

        private bool FeedbackItemExists(long id)
        {
            return _context.FeedbackItems.Any(e => e.Id == id);
        }
    }
}
