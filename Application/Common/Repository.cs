using Domain.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public abstract class Repository<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly ExamsAppDbContext context;
        public DbSet<T> Entities;
        public List<Exception> RepositoryExceptions;

        public Repository(ExamsAppDbContext _context)
        {
            context = _context;
            Entities = context.Set<T>();
        }
        /// <summary>
        /// Gets the entity without join tables - no including
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> GetByIdAsync(long id)
        {
            return await Entities.FindAsync(id);
        }

        public IQueryable<T> GetAllAsync()
        {
            return Entities;
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                RepositoryExceptions.Add(new ArgumentNullException($"{nameof(AddAsync)} entity must not be null"));
            }
            try
            {
                await Entities.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                RepositoryExceptions.Add(new Exception($"{nameof(entity)} could not be saved: {ex.Message}"));
            }
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
            {
                RepositoryExceptions.Add(new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null"));
            }
            try
            {
                Entities.Remove(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                RepositoryExceptions.Add(new Exception($"{nameof(entity)} could not be deleted: {ex.Message}"));
            }
        }

        public async Task EditAsync(T entity, object key)
        {
            if (entity == null)
            {
                RepositoryExceptions.Add(new ArgumentNullException($"{nameof(EditAsync)} entity must not be null"));
            }
            T exist = await Entities.FindAsync(key);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
            }
        }


    }
}
