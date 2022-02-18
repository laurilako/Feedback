using Feedback.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Feedback.FeedbackData
{
    public class SqlFeedback : IFeedback
    {
        private readonly FeedbackContext _context;

        public SqlFeedback(FeedbackContext context)
        {
            _context = context;
        }

        // GET all from db
        public IEnumerable<FeedbackItem> GetFeedbackItems()
        {
            return _context.FeedbackItems.ToList();
        }

        // GET id from db
        public FeedbackItem GetItemById(int id)
        {
            return _context.FeedbackItems.FirstOrDefault(p => p.Id == id);
        }
    }
}
