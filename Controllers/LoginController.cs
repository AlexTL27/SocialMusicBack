using Microsoft.AspNetCore.Mvc;
using SocialMusic.Data;
using SocialMusic.Models;
using System.Runtime.InteropServices;


namespace SocialMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly AppDbContext _context;

        //Obtener la BD
        public LoginController(AppDbContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult Login([FromBody] CLoginRequest login)
        {
            var usuario = _context.UsuariosMusicos.FirstOrDefault(u => u.Email == login.Email);

            if (usuario == null) 
                return BadRequest(new { mensaje = "Email aún no registrado", exito = false });


            bool correctHash = BCrypt.Net.BCrypt.Verify(login.Password,usuario.Password);

            if (!correctHash) 
                return BadRequest(new { mensaje = "Contraseña incorrecta", exito = false });


            //Generar Token para Validaciones


            return Ok(new { mensaje = "Login exitoso", exito = true });
        }


    }
}
