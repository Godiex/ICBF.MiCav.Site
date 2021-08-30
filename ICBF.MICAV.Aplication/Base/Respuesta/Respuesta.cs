using System;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using Aplicacion.Base;
using ICBF.MICAV.Domain.Common;

namespace ICBF.MICAV.Aplication.Base
{
    public abstract class BaseRespuesta
    {
        public string Mensaje { get; set; }
        public bool Error { get; set; }
        public string DetallaTransaccion { get; set; }
        public HttpStatusCode Codigo { get; set; }
    }

    public class Respuesta<T> : BaseRespuesta, IRespuesta<T>
    {
        public T Datos { get; set; }

        public static Respuesta<T> CrearRespuestaExitosa(T datos, HttpStatusCode codigo, string mensaje)
        {
            return new Respuesta<T>
            {
                Codigo = codigo,
                Datos = datos,
                Error = false,
                Mensaje = mensaje,
                DetallaTransaccion = $"Transaccion exitosa sobre {ObtenerNombreClase(datos)}"
            };
        }
        
        public static Respuesta<T> CrearRespuestaFallida(string clase,string funcion, HttpStatusCode codigo, string mensaje) 
        {
            return new Respuesta<T>
            {
                Mensaje = mensaje,
                Codigo = codigo,
                Error = true,
                DetallaTransaccion = $"Fallo en {clase} en el metodo : '{funcion}' "
            };
        }
        
        public static Respuesta<T> CrearRespuestaFallida(Exception e, string clase, string metodo, HttpStatusCode codigo, string mensaje) 
        {
            return new Respuesta<T>
            {
                Mensaje = mensaje,
                Codigo = codigo,
                Error = true,
                DetallaTransaccion = $"Excepcion en {clase}, Metodo '{metodo}', {ObtenerLineaError(e)}, Error : {e.Message}"
            };
        }
        
        private static string ObtenerNombreClase(T datos)
        {
            return CallerMember.GetClassName(datos);
        }
        
        private static string ObtenerLineaError(dynamic e)
        {
            return ErrorLine.GetNumber(e);
        }

    }
}