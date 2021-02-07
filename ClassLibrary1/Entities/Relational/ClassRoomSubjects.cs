using Domain.Entities.ObjectEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities.Relational
{
    public class ClassRoomSubjects
    {
        public long ClassRoomId { get; set; }
        public ClassRoom ClassRoom { get; set; }
        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
