using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, IAggregateRoot
    {
        private readonly ExamPrjDbContext context;
        private readonly DbSet<T> entities;
        public List<Exception> RepositoryExceptions;

        public GenericRepository(ExamPrjDbContext _context)
        {
            context = _context;
            entities = context.Set<T>();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            return await entities.FindAsync(id);
        }

        public IQueryable<T> GetAllAsync()
        {
            return entities;
        }

        public async Task AddAsync(T entity)
        {
            if (entity == null)
            {
                RepositoryExceptions.Add(new ArgumentNullException($"{nameof(AddAsync)} entity must not be null"));
            }
            try
            {
                await entities.AddAsync(entity);
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
                entities.Remove(entity);
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
            T exist = await entities.FindAsync(key);
            if (exist != null)
            {
                context.Entry(exist).CurrentValues.SetValues(entity);
                await context.SaveChangesAsync();
            }
        }

        //public async Task<bool> SaveChangesAsync()
        //{
        //    return await context.SaveChangesAsync() > 0;
        //}


        //public Task<IQueryable<ClassRoom>> FindClassRoomByStudentAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<IQueryable<ClassRoom>> FindClassRoomByTeacherAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
