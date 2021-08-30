using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using ICBF.MICAV.Aplication.Base;
using ICBF.MICAV.Aplication.Http.Dto.Usuario;
using ICBF.MICAV.Domain.Common;
using ICBF.MICAV.Domain.Contract;
using ICBF.MICAV.Domain.Entities;
using ICBF.MICAV.Domain.Repositories;
using ICBF.MICAV.Infrastructure.Encrypt;

namespace ICBF.MICAV.Aplication
{
    public class ServicioUsuario : Servicio<Usuario>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IMapper _mapper;

        public ServicioUsuario(IUnidadDeTrabajo unidadDeTrabajo, IMapper mapper) : base(unidadDeTrabajo)
        {
            _repositorioUsuario = unidadDeTrabajo.RepositorioUsuario;
            _mapper = mapper;
        }

        public async Task<Respuesta<UsuarioDto>> Crear(UsuarioRequest request)
        {
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(request);
                return await RealizarRegistro(usuario);
            }
            catch (Exception e)
            {
                UnidadDeTrabajo.RollBack();
                return Respuesta<UsuarioDto>.CrearRespuestaFallida(e,NombreServicio, CallerMember.GetNameMethod(), 
                    HttpStatusCode.BadRequest, "Error al crear usuario");
            }
        }

        private async Task<Respuesta<UsuarioDto>> RealizarRegistro(Usuario usuario)
        {
            bool existeUsuario = await ExisteUsuario(usuario);
            if (existeUsuario)
            {
                return Respuesta<UsuarioDto>.CrearRespuestaFallida(NombreServicio,CallerMember.GetNameMethod(),
                    HttpStatusCode.Conflict, "el usuario ya existe");
            }

            usuario.Contrasena = Hash.GetSha256(usuario.Contrasena);
            UnidadDeTrabajo.BeginTransaction();
            await _repositorioUsuario.Agregar(usuario);
            UnidadDeTrabajo.Commit();
            var usuarioDto = _mapper.Map<UsuarioDto>(usuario);
            return Respuesta<UsuarioDto>.CrearRespuestaExitosa(usuarioDto, HttpStatusCode.Created,
                "Usuario creado con exito");
        }

        private async Task<bool> ExisteUsuario(Usuario usuario)
        {
            bool existeUsuario =
                await _repositorioUsuario.ExisteRegistro(u => u.NombreUsuario == usuario.NombreUsuario);
            return existeUsuario;
        }
    }
}