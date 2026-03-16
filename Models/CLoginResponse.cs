namespace SocialMusic.Models
{
    public class CLoginResponse
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }

        public string Token { get; set; }

        public UsuarioDTO Usuario { get; set; }
    }


    //Clase de usuario que saldra del Back
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public string Email { get; set; } = "";
    }
}
