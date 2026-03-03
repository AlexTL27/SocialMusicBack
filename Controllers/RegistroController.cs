using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMusic.Models;

namespace SocialMusic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {
        [HttpPost]
        public IActionResult RegistrarMusico([FromBody] CUsuarioMusico registro)
        {
            if (registro == null) return BadRequest("Datos Inválidos");


            //Lógica



            Console.WriteLine("Alguien ha enviado datos");

            return Ok(new { mensaje = "Usuario registrado con exito", exito = true }); 
        }
    }
}
