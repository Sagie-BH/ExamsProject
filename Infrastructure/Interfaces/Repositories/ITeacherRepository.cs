using Domain.Entities.UserEntities;
using Domain.Interfaces;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Repositories
{
    public interface ITeacherRepository : IRepository<Teacher> 
    {
        Task<Teacher> GetTeacherById(long id);

    }
}
