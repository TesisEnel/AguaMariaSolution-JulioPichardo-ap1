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

            var empleadoEncontrado = await _context.Empleados.FirstOrDefaultAsync(e => e.Email == login.Correo && e.Clave == login.Clave);
            var empleadoEncontradoNot = await _context.Empleados.FirstOrDefaultAsync(e => e.Email == login.Correo && e.Clave != login.Clave);

            if (login.Correo == "julio@gmail.com" && login.Clave == "admin" || login.Correo == "abraham@gmail.com" && login.Clave == "admin")
            {
                sesionAMS.Nombre = "admin";
                sesionAMS.Correo = login.Correo;
                sesionAMS.Rol = "Administrador";
            }
            else if (empleadoEncontrado != null)
            {
                sesionAMS.Nombre = empleadoEncontrado.Nombre;
                sesionAMS.Correo = login.Correo;
                sesionAMS.Rol = "Empleado";
            }
            else if (empleadoEncontradoNot != null)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Contraseña incorrecta");
            }
            else
            {
                sesionAMS.Nombre = "cliente";
                sesionAMS.Correo = login.Correo;
                sesionAMS.Rol = "Cliente";
            }

            return StatusCode(StatusCodes.Status200OK, sesionAMS);
        }
    }
}
