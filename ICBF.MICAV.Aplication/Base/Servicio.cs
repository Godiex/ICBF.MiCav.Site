using ICBF.MICAV.Domain.Base;
using ICBF.MICAV.Domain.Contract;

namespace ICBF.MICAV.Aplication.Base
{
    public class Servicio<T>: BaseServicio, IServicio<T> where T : BaseEntidad
    {
        protected readonly IUnidadDeTrabajo UnidadDeTrabajo;
            
        protected Servicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            UnidadDeTrabajo = unidadDeTrabajo;
        }
    }

    public abstract class BaseServicio
    {
            
    }
}