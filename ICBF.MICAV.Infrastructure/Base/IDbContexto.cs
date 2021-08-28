using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ICBF.MICAV.Infrastructure.Base
{
    public interface IDbContexto
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry Entry(object entity);
        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        void SetModified(object entity);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }

    public class DbContextoBase : DbContext, IDbContexto
    {
        public DbContextoBase(DbContextOptions options) : base(options)
        { 
        }
        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}