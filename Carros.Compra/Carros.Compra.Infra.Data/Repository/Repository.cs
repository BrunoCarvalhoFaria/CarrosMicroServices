
using Carros.Compra.Domain.DTO;
using Carros.Compra.Domain.Interfaces;
using Carros.Compra.Domain.Models;
using Carros.Compra.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Linq.Expressions;

namespace Carros.Compra.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>, IDisposable where TEntity : Entity<TEntity>
    {
        protected readonly CarrosCompraDbContext data;
        protected readonly string stringConnection;
        private bool disposedValue;


        protected Repository(CarrosCompraDbContext context)
        {
            data = context;
            stringConnection = Configuracoes.Configuration.GetConnectionString("ConnectionMysql")!;

        }

        public long Id { get; protected set; }
        public virtual bool Excluido { get; set; }

        public void Excluir()
        {
            Excluido = true;
        }

        public async Task Add(TEntity Objeto)
        {

            await data.Set<TEntity>().AddAsync(Objeto);
            await data.SaveChangesAsync();

        }

        public async Task Delete(TEntity Objeto)
        {
            data.Set<TEntity>().Remove(Objeto);
            await data.SaveChangesAsync();

        }


        public List<TEntity> GetAll()
        {
            return  data.Set<TEntity>().Where(t => t.Excluido == false).ToList();

        }

        public TEntity? GetById(long Id)
        {
            return data.Set<TEntity>().Where(t => t.Excluido == false && t.Id == Id).FirstOrDefault();


        }

        public void Update(TEntity Objeto)
        {
            try
            {
                DetachEntity(Objeto, Objeto.Id);
                Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
         
     

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        public void DetachEntity(TEntity t, long entryId)
        {
            var attachedEntity = data.Set<TEntity>()
                .FirstOrDefault(entry => entry.Id.Equals(entryId));
            if (attachedEntity != null)
            {
                data.Entry(attachedEntity).State = EntityState.Detached;
            }
            data.Entry(t).State = EntityState.Modified;
        }

        private void Save()
        {
            try
            {
                data.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }


};