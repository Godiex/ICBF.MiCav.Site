using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ICBF.MICAV.Domain.Base
{
    public abstract class BaseEntidad
    {
        private string UsuarioCrea { get; set; }
        private string UsuarioModifica { get; set; }
        private DateTime FechaCrea { get; set; }
        private DateTime? FechaModifica { get; set; }
        public bool Estado { get; set; }
    }
    
    public abstract class Entidad<T> : BaseEntidad, IEntidad<T>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }
    }

}