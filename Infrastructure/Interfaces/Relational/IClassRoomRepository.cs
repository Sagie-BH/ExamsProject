using Domain.Entities.Relational;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Relational
{
    public interface IClassRoomRepository : IGenericRepository<ClassRoom>
    {
        Task<ClassRoom> GetClassRoomByTeacher(long teacherId);
    }

}
