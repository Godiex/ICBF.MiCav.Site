using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICBF.MICAV.Domain.Base
{
    public abstract class BaseEntidad
    {
        public string UsuarioCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public DateTime FechaCrea { get; set;} = DateTime.Now;
        public DateTime? FechaModifica { get; set; }
        public bool Estado { get; set; } = true;
    }
    
    public abstract class Entidad<T> : BaseEntidad, IEntidad<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }
    }

}