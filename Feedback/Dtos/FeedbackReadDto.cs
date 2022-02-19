namespace Feedback.Dtos
{
    public class FeedbackReadDto
    {
        // Mitä palautetaan esim. GET pyyntöön.
        public long Id { get; set; } // ID

        public string Name { get; set; } // Palautteen saajan nimi

        public string FeedbackString { get; set; } // Palauteviesti

        public bool Status { get; set; } // Vastattu? true=kuitattu tai false=ei vielä kuitattu
    }
}
