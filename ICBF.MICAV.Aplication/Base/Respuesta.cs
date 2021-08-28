using System.Net;
using Aplicacion.Base;

namespace ICBF.MICAV.Aplication.Base
{
    public abstract class BaseRespuesta
    {
        public string Mensaje { get; set; }
        public HttpStatusCode Codigo { get; set; }
    }

    public class Respuesta<T> : BaseRespuesta, IRespuesta<T>
    {
        public T Datos { get; set; }

        public static Respuesta<T> CrearRespuestaFallida(dynamic datos, HttpStatusCode codigo, string mensaje) 
        {
            return new Respuesta<T>
            {
                Mensaje = mensaje,
                Codigo = codigo,
                Datos = datos
            };
        }
        
        public static Respuesta<T> CrearRespuestaExitosa(T datos, HttpStatusCode codigo, string mensaje)
        {
            return new Respuesta<T>
            {
                Codigo = codigo,
                Datos = datos,
                Mensaje = mensaje,
            };
        }
        
    }
}