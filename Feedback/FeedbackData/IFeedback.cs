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
        void CreateFeedback(FeedbackItem feedback);

        // Päivitä palautetta (pääasiassa status false->true)
        void UpdateFeedback(FeedbackItem feedback);

        // Poista palaute
        void DeleteFeedback(FeedbackItem feedback);

        // Tallenna muutokset
        bool SaveChanges();
    }
}
