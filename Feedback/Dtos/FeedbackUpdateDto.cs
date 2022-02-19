using System.ComponentModel.DataAnnotations;

namespace Feedback.Dtos
{
    public class FeedbackUpdateDto
    {
        // Mitä vaaditaan POST pyyntöön, eli uuden palautteen luomiseen.
        // ID ei tarvita.
        // Lisätään dataAnnotationit, jotta jos näitä ei toimiteta uutta luodessa, niin API palauttaa 400 errorin.

        [Required]
        public string Name { get; set; } // Palautteen saajan nimi

        [Required]
        [MaxLength(200)]
        public string FeedbackString { get; set; } // Palauteviesti

        public bool Status { get; set; } // Vastattu? true=kuitattu tai false=ei vielä kuitattu
    }
}
