using Feedback.Models;
using Feedback.Dtos;
using AutoMapper;


namespace Feedback.Profiles
{
    public class FeedbackItemsProfile : Profile
    {
        public FeedbackItemsProfile()
        {
            CreateMap<FeedbackItem, FeedbackReadDto>();
        }




    }
}
