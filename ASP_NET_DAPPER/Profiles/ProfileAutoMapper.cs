using ASP_NET_DAPPER.Dto.Usuario;
using ASP_NET_DAPPER.Models;
using AutoMapper;

namespace ASP_NET_DAPPER.Profiles
{
    public class ProfileAutoMapper : Profile
    {

        public ProfileAutoMapper()
        {
            CreateMap<UsuarioModel, UsuarioListarDTO>();
        }



    }
}
