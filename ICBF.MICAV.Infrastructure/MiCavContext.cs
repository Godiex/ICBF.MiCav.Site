using ICBF.MICAV.Domain.Entities;
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
        public DbSet<Usuario> Users { get; set; }
        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            
        }
        
    }
}