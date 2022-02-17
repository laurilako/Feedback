using Microsoft.EntityFrameworkCore;

namespace Feedback.Models
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> options)
            : base(options)
        {

        }
    
        public DbSet<FeedbackItem> FeedbackItems { get; set; }
    }
}
