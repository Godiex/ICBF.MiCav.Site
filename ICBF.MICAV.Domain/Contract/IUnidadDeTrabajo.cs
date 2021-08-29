using System;
using System.Threading.Tasks;
using ICBF.MICAV.Domain.Repositories;

namespace ICBF.MICAV.Domain.Contract
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        #region [Respositorios]
        public IRepositorioUsuario RepositorioUsuario { get;}
        #endregion
        
        void Commit();
        void RollBack();
        Task GuardarCambios();
        void BeginTransaction();
        
    }
}