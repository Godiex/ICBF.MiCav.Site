using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ICBF.MICAV.Domain.Base;

namespace ICBF.MICAV.Domain.Entities
{
    public class Usuario : Entidad<int>
    {
        [Required]
        public string CodigoUsuario { get; set; }
        public string NombreUsuario { get; set; }
        [Column("usuario")]
        public string Contrasena { get; set; }
        [Required]       
        public int EstadoSesion { get; set; }
    }
}