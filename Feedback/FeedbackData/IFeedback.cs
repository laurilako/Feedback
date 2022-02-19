using System.Collections.Generic;
using Feedback.Models;

namespace Feedback.FeedbackData
{
    // Interace, joka tarjoaa käyttäjälle metodit
    public interface IFeedback
    {
        // Hae kaikki palautteet
        IEnumerable<FeedbackItem> GetFeedbackItems();
        
        // Hae palautetta sen ID:llä
        FeedbackItem GetItemById(int id);

        // Luo uusi palaute
        void CreateFeedback(FeedbackItem newFeedback);

        bool SaveChanges();
    }
}
