using ASP_NET_DAPPER.Dto.Usuario;
using ASP_NET_DAPPER.Services.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_DAPPER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        public readonly IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            _usuarioInterface = usuarioInterface;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var usuarios = await _usuarioInterface.GetUsuarios();

            if (!usuarios.Status)
            {
                return NotFound();
            }

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(int id)
        {
            var usuario = await _usuarioInterface.GetUsuarioById(id);

            if (!usuario.Status)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario(UsuarioCriarDto usuarioCriarDto)
        {
            var usuarios = await _usuarioInterface.CreateUsuario(usuarioCriarDto);

            if (!usuarios.Status)
            {
                return BadRequest(usuarios);
            }

            return Ok(usuarios);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUsuario(UsuarioEditarDto usuarioEditarDto)
        {
            var usuarios = await _usuarioInterface.UpdateUsuario(usuarioEditarDto);
            if (!usuarios.Status)
            {
                return BadRequest(usuarios);
            }

            return Ok(usuarios);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuarios = await _usuarioInterface.DeleteUsuario(id);
            if (!usuarios.Status)
            {
                return BadRequest(usuarios);
            }

            return Ok(usuarios);
        }


    }
}
