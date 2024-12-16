using Microsoft.AspNetCore.Mvc;
using WebApiUsuario.Models;
using WebApiUsuario.Data;

namespace WebApiUsuario.Controllers


{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;


        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        // Get : api/usuarios
        [HttpGet]
        public IActionResult ObtenerUsuarios()
        {
            var usuarios = _usuarioRepository.ObtenerUsuarios();
            return Ok(usuarios);
        }

        // Get : api / usuarios/ 5
        [HttpGet("{id}")]
        public IActionResult ObtenerUsuarioPorId(int id)
        {
            var usuario = _usuarioRepository.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        // Post : api/usuarios
        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }
            _usuarioRepository.CrearUsuario(usuario);
            return CreatedAtAction(nameof(ObtenerUsuarioPorId), new { id = usuario.Id }, usuario);




        }

        //Put : api / usuarios/5
        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario (int id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.Id != id)
            {
                return BadRequest();
            }

            var usuarioExistente = _usuarioRepository.ObtenerUsuarioPorId(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            _usuarioRepository.ActualizarUsuario(usuario);
            return NoContent(); // indica que la actualizacion fue exitosa sin necesidad de respuesta


        }
        // DELETE: api/usuarios/5
        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            var usuarioExistente = _usuarioRepository.ObtenerUsuarioPorId(id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            _usuarioRepository.EliminarUsuario(id);
            return NoContent(); // Indica que el recurso fue eliminado correctamente.
        }
    }
}

