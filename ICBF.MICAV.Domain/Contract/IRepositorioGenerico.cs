using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ICBF.MICAV.Domain.Base;

namespace ICBF.MICAV.Domain.Contract
{
    public interface IRepositorioGenerico<T> where T : BaseEntidad
    {
        Task<List<T>> ObtenerTodos(Func<IQueryable<T>, IOrderedQueryable<T>> ordenarPor, int pagina = 1,
            int tamanio = int.MaxValue);
        
        Task<T> ObtenerPorId(int id);
        Task<T> ObtenerPrimeroODeterminado(Expression<Func<T, bool>> predicado);
        Task<List<T>> ObtenerPor(Expression<Func<T, bool>> filtro = null, string propiedadesIncluidas = "",
            Func<IQueryable<T>, IOrderedQueryable<T>> ordenarPor = null);

        Task Agregar(T entidad);
        Task Editar(T entidad);
        Task Remover(T entidad);

        Task<IEnumerable<T>> ObtenerTodos();
        Task<IEnumerable<T>> ObtenerDonde(Expression<Func<T, bool>> predicado);

        Task<int> ContarTodos();
        Task<int> ContarDonde(Expression<Func<T, bool>> predicado);
    }
}