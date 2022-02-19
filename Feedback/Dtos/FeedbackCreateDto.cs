namespace Feedback.Dtos
{
    public class FeedbackCreateDto
    {
        // Mitä vaaditaan POST pyyntöön, eli uuden palautteen luomiseen.
        // ID ja Statuskoodia ei tarvita.
        public string Name { get; set; } // Palautteen saajan nimi

        public string FeedbackString { get; set; } // Palauteviesti
    }
}
