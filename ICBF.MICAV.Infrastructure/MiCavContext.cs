using ICBF.MICAV.Infrastructure.Base;
using Microsoft.EntityFrameworkCore;

namespace ICBF.MICAV.Infrastructure
{
    public class MiCavContext : DbContextoBase
    {
        public MiCavContext(DbContextOptions options) : base(options)
        {
            
        }

        #region DbSets
        
        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            
        }
        
    }
}