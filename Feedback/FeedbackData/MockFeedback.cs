using Feedback.Models;
using System.Collections.Generic;

// KOVAKOODATTUA DATAA TESTAAMISTA VARTEN
namespace Feedback.FeedbackData
{
    public class MockFeedback : IFeedback
    {
        public void CreateFeedback(FeedbackItem newFeedback)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<FeedbackItem> GetFeedbackItems()
        {
            var items = new List<FeedbackItem>
            {
                new FeedbackItem { Id = 0, Name="Jane", FeedbackString="Please dont do this", Status=true},
                new FeedbackItem { Id = 1, Name = "Jack", FeedbackString = "Good job on this one", Status = true },
                new FeedbackItem { Id = 2, Name = "Emil", FeedbackString = "Next time do this", Status = false },
                new FeedbackItem { Id = 3, Name = "Sasha", FeedbackString = "Nice job", Status = false }
            };

            return items;
        }

        public FeedbackItem GetItemById(int id)
        {
            return new FeedbackItem {Id=0, Name="Jane", FeedbackString="Please dont do this", Status=true};
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
