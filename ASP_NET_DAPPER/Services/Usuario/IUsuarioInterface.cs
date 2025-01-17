using ASP_NET_DAPPER.Dto.Usuario;
using ASP_NET_DAPPER.Models;

namespace ASP_NET_DAPPER.Services.Usuario
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioListarDTO>>> GetUsuarios();
        Task<ResponseModel<UsuarioListarDTO>> GetUsuarioById(int id);
        Task<ResponseModel<List<UsuarioListarDTO>>> CreateUsuario(UsuarioCriarDto usuarioCriarDto);
        Task<ResponseModel<List<UsuarioListarDTO>>> UpdateUsuario(UsuarioEditarDto usuarioEditarDto);
        Task<ResponseModel<List<UsuarioListarDTO>>> DeleteUsuario(int id);
    }
}
