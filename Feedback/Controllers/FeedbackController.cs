using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Feedback.Models;
using Feedback.FeedbackData;

namespace Feedback.Controllers
{
    //api/feedback
    //[Route("api/[controller]")]
    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedback _repository;
        // Repositoryn määrittäminen, riippuen kontekstista
        public FeedbackController(IFeedback repository)
        {
            _repository = repository;
        }

        // GET api/feedback/
        [HttpGet]
        public ActionResult<IEnumerable<FeedbackItem>> GetFeedbackItems()
        {
            var feedbackItems = _repository.GetFeedbackItems();
            return Ok(feedbackItems);
        }

        // GET api/feedback/{id}
        [HttpGet("{id}")]
        public ActionResult <FeedbackItem> GetItemById(int id)
        {
            var feedbackItem = _repository.GetItemById(id);
            return Ok(feedbackItem);

        }

    //    private readonly FeedbackContext _context;

    //    public FeedbackController(FeedbackContext context)
    //    {
    //        _context = context;
    //    }

    //    // GET: api/feedback
    //    [HttpGet]
    //    public async Task<ActionResult<IEnumerable<FeedbackItem>>> GetFeedbackItems()
    //    {
    //        return await _context.FeedbackItems.ToListAsync();
    //    }

    //    // GET: api/feedback/5
    //    [HttpGet("{id}")]
    //    public async Task<ActionResult<FeedbackItem>> GetFeedbackItem(long id)
    //    {
    //        var feedbackItem = await _context.FeedbackItems.FindAsync(id);

    //        if (feedbackItem == null)
    //        {
    //            return NotFound();
    //        }

    //        return feedbackItem;
    //    }

    //    // PUT: api/feedback/5
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> PutFeedbackItem(long id, FeedbackItem feedbackItem)
    //    {
    //        if (id != feedbackItem.Id)
    //        {
    //            return BadRequest();
    //        }

    //        _context.Entry(feedbackItem).State = EntityState.Modified;

    //        try
    //        {
    //            await _context.SaveChangesAsync();
    //        }
    //        catch (DbUpdateConcurrencyException)
    //        {
    //            if (!FeedbackItemExists(id))
    //            {
    //                return NotFound();
    //            }
    //            else
    //            {
    //                throw;
    //            }
    //        }

    //        return NoContent();
    //    }

    //    // POST: api/feedback
    //    [HttpPost]
    //    public async Task<ActionResult<FeedbackItem>> PostFeedbackItem(FeedbackItem feedbackItem)
    //    {
    //        _context.FeedbackItems.Add(feedbackItem);
    //        await _context.SaveChangesAsync();

    //        // return CreatedAtAction("GetFeedbackItem", new { id = feedbackItem.Id }, feedbackItem);
    //        return CreatedAtAction(nameof(GetFeedbackItem), new { id = feedbackItem.Id }, feedbackItem);
    //    }

    //    // DELETE: api/feedback/5
    //    [HttpDelete("{id}")]
    //    public async Task<ActionResult<FeedbackItem>> DeleteFeedbackItem(long id)
    //    {
    //        var feedbackItem = await _context.FeedbackItems.FindAsync(id);
    //        if (feedbackItem == null)
    //        {
    //            return NotFound();
    //        }

    //        _context.FeedbackItems.Remove(feedbackItem);
    //        await _context.SaveChangesAsync();

    //        return feedbackItem;
    //    }

    //    private bool FeedbackItemExists(long id)
    //    {
    //        return _context.FeedbackItems.Any(e => e.Id == id);
    //    }
    
    
    }
}
