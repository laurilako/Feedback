using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feedback.Models
{ 
    public class FeedbackItem
    {
        [Key]
        public long Id { get; set; } // ID

        [Required]
        public string Name { get; set; } // Palautteen saajan nimi

        [Required]
        [MaxLength(200)]
        public string FeedbackString { get; set; } // Palauteviesti
        
        [Required]
        [DefaultValue(false)]
        public bool Status { get; set; } // Vastattu? true tai false

    }
}
