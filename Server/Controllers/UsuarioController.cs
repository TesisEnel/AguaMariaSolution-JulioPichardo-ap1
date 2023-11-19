using AguaMariaSolution.Server.DAL;
using AguaMariaSolution.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace AguaMariaSolution.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly Contexto _context;

        public UsuarioController(Contexto context)
        {
            _context = context;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginAMS login)
        {
            SesionAMS sesionAMS = new SesionAMS();

            if (login.Correo == "julio@gmail.com" && login.Clave == "admin" || login.Correo == "abraham@gmail.com" && login.Clave == "admin")
            {
                sesionAMS.Nombre = "admin";
                sesionAMS.Correo = login.Correo;
                sesionAMS.Rol = "Administrador";
            }

            var empleadoEncontrado = await _context.Empleados.FirstOrDefaultAsync(e => e.Email == login.Correo);

            if (empleadoEncontrado != null && empleadoEncontrado.Clave==login.Clave)
            {
                sesionAMS.Nombre = empleadoEncontrado.Nombre;
                sesionAMS.Correo = login.Correo;
                sesionAMS.Rol = "Empleado";
            }
            else if (empleadoEncontrado == null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Usuario no encontrado");
            }
            else if (login.Clave != empleadoEncontrado.Clave)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Contraseña incorrecta");
            }

            return StatusCode(StatusCodes.Status200OK, sesionAMS);
        }
    }
}
