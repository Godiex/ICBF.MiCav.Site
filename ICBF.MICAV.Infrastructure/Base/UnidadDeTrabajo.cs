using System;
using System.Threading.Tasks;
using ICBF.MICAV.Domain.Common;
using ICBF.MICAV.Domain.Contract;
using ICBF.MICAV.Domain.Repositories;
using ICBF.MICAV.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ICBF.MICAV.Infrastructure.Base
{
    public class UnidadDeTrabajo: IUnidadDeTrabajo
    {
        private IDbContexto _dbContexto;
        private IDbContextTransaction _transaccion;
        
        public UnidadDeTrabajo(IDbContexto contexto)
        {
            _dbContexto = contexto;
        }
        
        #region [Respositorios]
        private IRepositorioUsuario _repositorioUsuario;

        public IRepositorioUsuario RepositorioUsuario => _repositorioUsuario ??= new RepositorioUsuario(_dbContexto);
        #endregion  
        
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing || _dbContexto == null) return;
            ((DbContext) _dbContexto).Dispose();
            _dbContexto = null;
        }
        
        public void BeginTransaction()
        {
            _transaccion = ((MiCavContext) _dbContexto).Database.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaccion?.Commit();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error  en {nameof(UnidadDeTrabajo)}.{CallerMember.GetNameMethod()}: {ex.Message}", ex);
            }
        }

        public void RollBack()
        {
            _transaccion?.Rollback();
        }

        public async Task GuardarCambios()
        {
            try
            {
                await _dbContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error  en {nameof(UnidadDeTrabajo)}.{CallerMember.GetNameMethod()}: {ex.Message}", ex);
            }
        }
        
    }
}