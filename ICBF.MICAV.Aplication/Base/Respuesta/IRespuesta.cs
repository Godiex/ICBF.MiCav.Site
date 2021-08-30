using System.Net;

namespace Aplicacion.Base
{
    public interface IRespuesta<T>
    {
        public HttpStatusCode Codigo { get; set; }
        T Datos { get; set; }
    }
}