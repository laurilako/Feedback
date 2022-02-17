using System.Collections.Generic;
using Feedback.Models;

namespace Feedback.FeedbackData
{
    // Interace, joka tarjoaa käyttäjälle metodit
    public interface IFeedback
    {
        // Hae kaikki feedback / palautteet
        IEnumerable<FeedbackItem> GetFeedbackItems();
        FeedbackItem GetItemById(int id);



    }
}
