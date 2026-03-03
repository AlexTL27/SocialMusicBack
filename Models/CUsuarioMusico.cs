namespace SocialMusic.Models
{
    public class CUsuarioMusico
    {
        //Atributos en inglés para evitar uso de acentos
        public string? Name { get; set; }
        public string? Password{ get; set; }

        public string? Email { get; set; }

        public string? Instrument { get; set; }

        //Es Género Musical
        public string? Gender { get; set; }


    }
}
