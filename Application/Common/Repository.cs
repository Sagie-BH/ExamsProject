using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public abstract class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        protected ExamsAppDbContext context;
        public DbSet<T> Entities;
        public List<Exception> RepositoryExceptions;

        public Repository(ExamsAppDbContext _context)
        {
            context = _context;
            Entities = context.Set<T>();
        }
        public long GetKey(T entity)
        {
            var keyName = context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties
                .Select(x => x.Name).Single();

            return (long)entity.GetType().GetProperty(keyName).GetValue(entity, null);
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await Entities.FindAsync(id);
        }

        public IQueryable<T> GetAllAsync()
        {
            return Entities;
        }

        public async Task<long> AddAsync(T entity)
        {
            if (entity == null)
            {
                RepositoryExceptions.Add(new ArgumentNullException($"{nameof(AddAsync)} entity must not be null"));
            }
            try
            {
                await Entities.AddAsync(entity);
                if(await context.SaveChangesAsync() > 0)
                {
                    return GetKey(entity);
                }
            }
            catch (Exception ex)
            {
                RepositoryExceptions.Add(new Exception($"{nameof(entity)} could not be saved: {ex.Message}"));
            }
            return 0;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                RepositoryExceptions.Add(new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null"));
            }
            try
            {
                Entities.Remove(entity);
                return await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                RepositoryExceptions.Add(new Exception($"{nameof(entity)} could not be deleted: {ex.Message}"));
            }
            return 0;
        }
        public async Task<int> EditAsync(T entity, long id)
        {
            if (entity == null)
            {
                RepositoryExceptions.Add(new ArgumentNullException($"{nameof(EditAsync)} entity must not be null"));
            }
            T exist = await Entities.FindAsync(id);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entity);
                return await context.SaveChangesAsync();
            }
            return 0;
        }


        public int GetCount()
        {
            return Entities.Count();
        }
    }
}
