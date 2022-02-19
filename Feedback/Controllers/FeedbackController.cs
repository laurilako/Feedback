﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Feedback.Models;
using Feedback.FeedbackData;
using Feedback.Dtos;
using AutoMapper;

namespace Feedback.Controllers
{
    //api/feedback
    //[Route("api/[controller]")]
    [Route("api/feedback")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {

        private readonly IFeedback _repository;
        private readonly IMapper _mapper;

        // Repositoryn määrittäminen ja mapperi olion tuominen kontrollerille
        public FeedbackController(IFeedback repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/feedback/
        [HttpGet]
        public ActionResult<IEnumerable<FeedbackItem>> GetFeedbackItems()
        {
            var feedbackItems = _repository.GetFeedbackItems();

            if (feedbackItems == null) {
                return NotFound();
            } else {
                return Ok(_mapper.Map<IEnumerable<FeedbackReadDto>>(feedbackItems));
            }
        }

        // GET api/feedback/{id}
        [HttpGet("{id}", Name="GetItemById")] // CreatedAtRoute ei toimi jos ei nimeä tätä metodin nimellä(?)
        public ActionResult <FeedbackReadDto> GetItemById(int id)
        {
            var feedbackItem = _repository.GetItemById(id);

            if (feedbackItem == null) {
                return NotFound();
            } else {
                return Ok(_mapper.Map<FeedbackReadDto>(feedbackItem));
            }
        }

        // TODO: Update ja Delete metodit... 

        // POST api/feedback
        [HttpPost]
        public ActionResult <FeedbackReadDto> CreateFeedback(FeedbackCreateDto feedbackCreateDto)
        {
            var feedbackModel = _mapper.Map<FeedbackItem>(feedbackCreateDto);
            _repository.CreateFeedback(feedbackModel);
            _repository.SaveChanges();

            var feedbackReadDto = _mapper.Map<FeedbackReadDto>(feedbackModel);

            // Palautuksen Headereissa annetaan location, minne uusi palaute tehtiin, em. /api/feedback/8
            return CreatedAtRoute(nameof(GetItemById), new {Id = feedbackReadDto.Id}, feedbackReadDto);
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
