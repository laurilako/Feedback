using Microsoft.EntityFrameworkCore;
using Feedback.Models;

// Konteksti databasen käytön/valinnan suhteen
namespace Feedback.FeedbackData
{
    public class FeedbackContext : DbContext
    {
        public FeedbackContext(DbContextOptions<FeedbackContext> opt) : base(opt)
        {

        }

        public DbSet<FeedbackItem> FeedbackItems { get; set; }

    }
}
