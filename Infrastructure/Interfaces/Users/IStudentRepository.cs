using Domain.Entities.UserEntities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces.Users
{
    public interface IStudentRepository : IGenericRepository<Student>
    {

    }
}
