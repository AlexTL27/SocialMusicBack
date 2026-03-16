using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SocialMusic.Data;
using SocialMusic.Models;
using SocialMusic.Services;
using System.Runtime.InteropServices;


namespace SocialMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;

        //Obtener la BD
        public LoginController(AppDbContext context, TokenService token)
        {
            _context = context;
            _tokenService = token;
        }


        [HttpPost]
        public IActionResult Login([FromBody] CLoginRequest login)
        {
            CUsuarioMusico? usuario = _context.UsuariosMusicos.FirstOrDefault(u => u.Email == login.Email);

            if (usuario == null) 
                return BadRequest(new { mensaje = "Email aún no registrado", exito = false });


            bool correctHash = BCrypt.Net.BCrypt.Verify(login.Password,usuario.Password);

            if (!correctHash) 
                return BadRequest(new { mensaje = "Contraseña incorrecta", exito = false });



            //Generar Token para Validaciones
            var token = _tokenService.GenerarToken(usuario);
            return Ok(new CLoginResponse
            { 
                Token = token,
                Mensaje = "Login exitoso", 
                Exito = true,
                Usuario = new UsuarioDTO {
                    Email = usuario.Email,
                    Name = usuario.Name,
                    Id = usuario.Id
                }
            });
        }

     
    }
}
