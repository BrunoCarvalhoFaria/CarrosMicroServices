using System.Linq.Expressions;

namespace Carros.Venda.Domain.Interfaces
{
    public interface IRepository { }

    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity Objeto);
        Task Delete(TEntity Objeto);
        TEntity? GetById(long Id);
        List<TEntity> GetAll();
        void Update(TEntity Objeto);

    }
}
