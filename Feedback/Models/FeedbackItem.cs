namespace Feedback.Models
{ 
    public class FeedbackItem
    {
        public long Id { get; set; } // Uniikki ID
        public string Name { get; set; } // Palautteen saaja
        public string FeedbackString { get; set; } // Palauteviesti
        public string Response { get; set; } // Palautteen vastaanottajan vastaus
        public bool Status { get; set; } // Vastattu? true tai false

    }
}
