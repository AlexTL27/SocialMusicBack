using System.ComponentModel.DataAnnotations;

namespace SocialMusic.Models
{
    public class CUsuarioMusico
    {
        public int Id { get; set; }
        //Atributos en inglés para evitar uso de acentos
        [Required]
        [MinLength(2)]
        public string Name { get; set; } = "";

        [Required]
        [EmailAddress]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";

        public string Instrument { get; set; } = "";

        //Es Género Musical
        public string Gender { get; set; } = "";

        public DateTime CreatedAt { get; set; }

        public bool IsActive { get; set; }

    }
}
