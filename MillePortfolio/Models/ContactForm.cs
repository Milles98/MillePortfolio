using System.ComponentModel.DataAnnotations;

namespace MillePortfolio.Models
{
    public class ContactForm
    {
        [Required(ErrorMessage = "Namn är obligatoriskt.")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Email är obligatoriskt.")]
        [EmailAddress(ErrorMessage = "Ogiltig emailadress.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Ämne är obligatoriskt.")]
        public string Subject { get; set; } = null!;

        [Required(ErrorMessage = "Meddelande är obligatoriskt.")]
        public string Message { get; set; } = null!;
    }
}
