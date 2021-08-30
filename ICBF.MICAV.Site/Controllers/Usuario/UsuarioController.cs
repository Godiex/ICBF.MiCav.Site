using System.Threading.Tasks;
using AutoMapper;
using ICBF.MICAV.Aplication;
using ICBF.MICAV.Aplication.Base;
using ICBF.MICAV.Domain.Contract;
using ICBF.MICAV.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ICBF.MICAV.Site
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        
        private readonly ServicioUsuario _servicioUsuario;

        public UsuarioController(IUnidadDeTrabajo unidadDeTrabajo, IMapper mapper)
        {
            _servicioUsuario = new ServicioUsuario(unidadDeTrabajo,mapper);
        }
        
        [HttpPost("Crear")]
        public async Task<ActionResult<Respuesta<Usuario>>> CreateUser([FromBody] UsuarioRequest request)
        {
            var respuesta = await _servicioUsuario.Crear(request);
            return StatusCode((int)respuesta.Codigo, respuesta);
        }
    }
}