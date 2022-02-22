using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Feedback.Models;
using Feedback.FeedbackData;
using Feedback.Dtos;
using AutoMapper;
using System;

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

        // PUT api/feedback/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateFeedback(int id, FeedbackUpdateDto feedbackUpdateDto)
        {
            var foundItem = _repository.GetItemById(id);
            if (foundItem == null)
            {
                return NotFound();
            }

            Console.Write(foundItem);
            
            _mapper.Map(feedbackUpdateDto, foundItem);

            // Ei tarpeellinen, mutta havainnoi mitä tehdään.
            _repository.UpdateFeedback(foundItem);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/feedback/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFeedback(int id)
        {
            var foundFeedback = _repository.GetItemById(id);
            if(foundFeedback == null)
            {
                return NotFound();
            }
            _repository.DeleteFeedback(foundFeedback);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}
