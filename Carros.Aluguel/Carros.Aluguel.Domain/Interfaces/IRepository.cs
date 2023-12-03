using System.Linq.Expressions;

namespace Carros.Aluguel.Domain.Interfaces
{
    public interface IRepository { }

    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity Objeto);
        Task DeleteAsync(TEntity Objeto);
        TEntity? GetById(long Id);
        List<TEntity> GetAll();
        void Update(TEntity Objeto);

    }
}

