using ICBF.MICAV.Domain.Entities;
using ICBF.MICAV.Domain.Repositories;
using ICBF.MICAV.Infrastructure.Base;

namespace ICBF.MICAV.Infrastructure.Repositories
{
    public class RepositorioUsuario : RepositorioGenerico<Usuario>, IRepositorioUsuario
    {
        protected RepositorioUsuario(IDbContexto contexto) : base(contexto)
        {
        }
    }
}