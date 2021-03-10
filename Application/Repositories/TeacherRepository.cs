using Application.Common;
using Domain.Entities.UserEntities;
using Infrastructure.Interfaces.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public class TeacherRepository : Repository<Teacher>, ITeacherRepository
    {
        public TeacherRepository(ExamsAppDbContext context) : base(context) { }

        /// <summary>
        /// Gets the teacher full details + Students LIst & PersonalClasses List
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Teacher> GetTeacherByIdAsync(long id)
        {
            return await Entities.Include(t => t.MyClasses).ThenInclude(c => c.Subject)
                .Include(t => t.MyClasses).ThenInclude(c => c.Students)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
