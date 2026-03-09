using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMusic.Data;
using SocialMusic.Models;

namespace SocialMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        private readonly AppDbContext _context;

        //Obtener la BD
        public RegistroController(AppDbContext context) 
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult RegistrarMusico([FromBody] CUsuarioMusico registro)
        {
            if (registro == null || !ModelState.IsValid) 
            {
                var mensaje = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage);
                return BadRequest(new { mensaje, exito = false }); 
            }
            if (_context.UsuariosMusicos.Any(c => c.Email == registro.Email)) return BadRequest(new {mensaje = "El email ya está registrado", exito = false });

            try
            {
                //Creamos el usuario
                CUsuarioMusico temp = new CUsuarioMusico
                {
                    Name = registro.Name.Trim(),
                    Email = registro.Email.Trim(),
                    Instrument = registro.Instrument,
                    Gender = registro.Gender,

                    Password = BCrypt.Net.BCrypt.HashPassword(registro.Password)


                };

                _context.UsuariosMusicos.Add(temp);
                _context.SaveChanges();


                Console.WriteLine("Hola");
                return Ok(new { mensaje = "Usuario registrado con exito", exito = true });
            }
            catch
            {
                return BadRequest(new { mensaje = "Opps, Ha ocurrido un error", exito = false });
            }
    
        }
    }
}
