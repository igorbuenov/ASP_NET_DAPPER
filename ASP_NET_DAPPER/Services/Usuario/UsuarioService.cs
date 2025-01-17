using ASP_NET_DAPPER.Dto.Usuario;
using ASP_NET_DAPPER.Models;
using AutoMapper;
using Dapper;
using System.Data.SqlClient;

namespace ASP_NET_DAPPER.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {

        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public UsuarioService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<ResponseModel<List<UsuarioListarDTO>>> CreateUsuario(UsuarioCriarDto usuarioCriarDto)
        {
            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();

            using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                var usuariosBanco = await connection.ExecuteAsync("INSERT INTO Usuarios (Nome, Email, Cargo, Salario, CPF, Situacao, Senha) " +
                                                                  "VALUES (@Nome, @Email, @Cargo, @Salario, @CPF, @Situacao, @Senha)", usuarioCriarDto);

                if(usuariosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar o cadastro dousuário!";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);
                var usuariosMap = _mapper.Map<List<UsuarioListarDTO>>(usuarios);

                response.Dados = usuariosMap;
                response.Mensagem = "Registros de usuários listados com sucesso!";  
            }

            return response;
        }

        public async Task<ResponseModel<UsuarioListarDTO>> GetUsuarioById(int id)
        {
            ResponseModel<UsuarioListarDTO> response = new ResponseModel<UsuarioListarDTO>();

            using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuario = await connection.QueryFirstOrDefaultAsync<UsuarioModel>("SELECT * FROM Usuarios WHERE Id = @Id", new {Id = id});

                if (usuario == null)
                {
                    response.Mensagem = "Não há registro encontrado!";
                    response.Status = false;
                    return response;
                }

                var usuarioMap = _mapper.Map<UsuarioListarDTO>(usuario);

                response.Dados = usuarioMap;
                response.Mensagem = "Registro de usuário localizado com sucesso!";
            }

            return response;
        }

        public async Task<ResponseModel<List<UsuarioListarDTO>>> GetUsuarios()
        {

            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();

            using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                var usuarios = await connection.QueryAsync<UsuarioModel>("SELECT * FROM Usuarios");

                if(usuarios.Count() == 0)
                {
                    response.Mensagem = "Não há registro de usuários!";
                    response.Status = false;
                    return response;
                }

                // Conversão com Mapper
                var usuariosMap = _mapper.Map<List<UsuarioListarDTO>>(usuarios);

                response.Dados = usuariosMap;
                response.Mensagem = "Usuários localizados com sucesso!";

            }

            return response;
        }

        public async Task<ResponseModel<List<UsuarioListarDTO>>> UpdateUsuario(UsuarioEditarDto usuarioEditarDto)
        {
            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                var usuariosBanco = await connection.ExecuteAsync("UPDATE Usuarios " +
                                                                    "SET " +
                                                                        "Nome = @Nome" +
                                                                        ", Email = @Email" +
                                                                        ", Cargo = @Cargo" +
                                                                        ", Salario = @Salario" +
                                                                        ", Situacao = @Situacao" +
                                                                        ", CPF = @CPF " +
                                                                    "WHERE " +
                                                                        "Id = @Id", usuarioEditarDto);

                if (usuariosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao realizar a edição do usuário!";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);
                var usuariosMap = _mapper.Map<List<UsuarioListarDTO>>(usuarios);

                response.Dados = usuariosMap;
                response.Mensagem = "Registros de usuários listados com sucesso!";
            }

            return response;
        }
        public async Task<ResponseModel<List<UsuarioListarDTO>>> DeleteUsuario(int id)
        {
            ResponseModel<List<UsuarioListarDTO>> response = new ResponseModel<List<UsuarioListarDTO>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                var usuariosBanco = await connection.ExecuteAsync("DELETE FROM Usuarios WHERE Id = @Id", new {Id = id});

                if (usuariosBanco == 0)
                {
                    response.Mensagem = "Ocorreu um erro ao deletar o usuário!";
                    response.Status = false;
                    return response;
                }

                var usuarios = await ListarUsuarios(connection);
                var usuariosMap = _mapper.Map<List<UsuarioListarDTO>>(usuarios);

                response.Dados = usuariosMap;
                response.Mensagem = "Registros de usuários listados com sucesso!";
            }

            return response;
        }

        // UTILITÁRIOS
        private static async Task<IEnumerable<UsuarioModel>> ListarUsuarios(SqlConnection connection)
        {
            return await connection.QueryAsync<UsuarioModel>("SELECT * FROM Usuarios");
        }

        
    }
}
