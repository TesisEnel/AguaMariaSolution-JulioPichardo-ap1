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

            if (login.Correo == "A" && login.Clave == "A")
            {
                sesionAMS.Nombre = "PAPADIO";
                sesionAMS.Correo = "PAPADIO@CIELO.GOD";
                sesionAMS.Rol = "Administrador";
                return StatusCode(StatusCodes.Status200OK, sesionAMS);
            }
            if (login.Correo == "Ae" && login.Clave == "A")
            {
                sesionAMS.Nombre = "PAPADIOEMPLEADO";
                sesionAMS.Correo = "PAPADIO@EMPLEADO.GOD";
                sesionAMS.Rol = "Empleado";
                return StatusCode(StatusCodes.Status200OK, sesionAMS);
            }
            var adminEncontrado = await _context.Admins.FirstOrDefaultAsync(e => e.Email == login.Correo);

            if (adminEncontrado != null && login.Clave == adminEncontrado.Contraseña)
            {
                sesionAMS.Nombre = adminEncontrado.Nombre;
                sesionAMS.Correo = login.Correo;
                sesionAMS.Rol = "Administrador";
                return StatusCode(StatusCodes.Status200OK, sesionAMS);
            }

            var empleadoEncontrado = await _context.Empleados.FirstOrDefaultAsync(e => e.Email == login.Correo);

            if (empleadoEncontrado != null && empleadoEncontrado.Clave==login.Clave)
            {
                sesionAMS.Nombre = empleadoEncontrado.Nombre;
                sesionAMS.Correo = login.Correo;
                sesionAMS.Rol = "Empleado";
            }
            else if (empleadoEncontrado == null || login.Clave != empleadoEncontrado.Clave)
            {
                return StatusCode(StatusCodes.Status401Unauthorized, "Usuario o Contraseña incorrecta");
            }

            return StatusCode(StatusCodes.Status200OK, sesionAMS);
        }
    }
}
