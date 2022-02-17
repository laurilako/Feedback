using Feedback.Models;
using System.Collections.Generic;

// KOVAKOODATTUA DATAA TESTAAMISTA VARTEN
namespace Feedback.FeedbackData
{
    public class MockFeedback : IFeedback
    {
        public IEnumerable<FeedbackItem> GetFeedbackItems()
        {
            var items = new List<FeedbackItem>
            {
                new FeedbackItem { Id = 0, Name="Jane", FeedbackString="Please dont do this", Response="Allright", Status=true},
                new FeedbackItem { Id = 1, Name = "Jack", FeedbackString = "Good job on this one", Response = "Yeah got that", Status = true },
                new FeedbackItem { Id = 2, Name = "Emil", FeedbackString = "Next time do this", Response = "No problem", Status = true },
                new FeedbackItem { Id = 3, Name = "Sasha", FeedbackString = "Nice job", Response = "", Status = false }
            };

            return items;
        }

        public FeedbackItem GetItemById(int id)
        {
            return new FeedbackItem {Id=0, Name="Jane", FeedbackString="Please dont do this", Response="Allright", Status=true};
        }











    }
}
