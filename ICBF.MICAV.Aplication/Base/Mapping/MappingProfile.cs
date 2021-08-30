

using AutoMapper;
using ICBF.MICAV.Aplication;
using ICBF.MICAV.Aplication.Http.Dto.Usuario;
using ICBF.MICAV.Domain.Entities;

namespace ICBF.MICAV.Site
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UsuarioRequest, Usuario>();
            CreateMap<Usuario, UsuarioDto>();
        }
    }
}