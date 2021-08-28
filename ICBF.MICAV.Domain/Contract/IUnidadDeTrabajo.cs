using System;
using System.Threading.Tasks;

namespace ICBF.MICAV.Domain.Contract
{
    public interface IUnidadDeTrabajo: IDisposable
    {
        #region [Respositorios]
        #endregion
        
        void Commit();
        void Rollback();
        Task SaveChanges();
        void BeginTransaction();
        
    }
}