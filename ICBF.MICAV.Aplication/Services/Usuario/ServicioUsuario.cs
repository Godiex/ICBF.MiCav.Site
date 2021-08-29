using System;
using System.Net;
using System.Threading.Tasks;
using ICBF.MICAV.Aplication.Base;
using ICBF.MICAV.Domain.Contract;
using ICBF.MICAV.Domain.Entities;
using ICBF.MICAV.Domain.Repositories;
using ICBF.MICAV.Infrastructure.Base;
using ICBF.MICAV.Infrastructure.Repositories;

namespace ICBF.MICAV.Aplication
{
    public class ServicioUsuario : Servicio<Usuario>
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public ServicioUsuario(IUnidadDeTrabajo unidadDeTrabajo) : base(unidadDeTrabajo)
        {
            _repositorioUsuario = unidadDeTrabajo.RepositorioUsuario;
        }

        public async Task<Respuesta<Usuario>> Crear(Usuario usuario)
        {
            try
            {
                Respuesta<Usuario> respuesta = await RealizarRegistro(usuario);
                return respuesta;
            }
            catch (Exception e)
            {
                UnidadDeTrabajo.RollBack();
                return Respuesta<Usuario>.CrearRespuestaFallida(usuario,HttpStatusCode.BadRequest, 
                    "Error al crear usuario");
            }
        }

        private async Task<Respuesta<Usuario>> RealizarRegistro(Usuario usuario)
        {
            bool existeUsuario =
                await _repositorioUsuario.ExisteRegistro(u => u.NombreUsuario == usuario.NombreUsuario);
            if (!existeUsuario)
            {
                UnidadDeTrabajo.BeginTransaction();
                await _repositorioUsuario.Agregar(usuario);
                UnidadDeTrabajo.Commit();
                return Respuesta<Usuario>.CrearRespuestaExitosa(usuario, HttpStatusCode.Created,
                    "Usuario creado con exito");
            }
            return Respuesta<Usuario>.CrearRespuestaFallida(usuario, HttpStatusCode.Conflict,
                "el usuario ya existe");
        }
    }
}