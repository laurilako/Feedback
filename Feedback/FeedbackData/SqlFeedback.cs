using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Feedback.FeedbackData
{
    public class SqlFeedback : IFeedback
    {
        private readonly FeedbackContext _context;

        public SqlFeedback(FeedbackContext context)
        {
            _context = context;
        }

        // Luo uusi palaute databaseen
        public void CreateFeedback(FeedbackItem feedback)
        {
            if(feedback == null)
            {
                throw new ArgumentNullException();
            } else
            {
                _context.FeedbackItems.Add(feedback);
            }
        }

        // Hae kaikki dbstä
        public IEnumerable<FeedbackItem> GetFeedbackItems()
        {
            return _context.FeedbackItems.ToList();
        }

        // Hae ID:llä dbstä
        public FeedbackItem GetItemById(int id)
        {
            return _context.FeedbackItems.FirstOrDefault(p => p.Id == id);
        }

        // Päivitä feedbackia
        public void UpdateFeedback(FeedbackItem feedback)
        {
            // Dbcontext päivittää feedbackin
        }

        // Poista feedback
        public void DeleteFeedback(FeedbackItem feedback)
        {
            if(feedback == null)
            {
                throw new ArgumentNullException();
            }

            _context.FeedbackItems.Remove(feedback);
        }

        // tallenna muutokset databaseen
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >=  0);
        }
    }
}
