using Domain.Entities.ObjectEntities;
using Domain.Entities.Relational;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Persistence.Configuration.AppObjects
{
    public class AppExamConfiguration : IEntityTypeConfiguration<AppExam>
    {
        public void Configure(EntityTypeBuilder<AppExam> builder)
        {
            builder.Property(ae => ae.SuccessRate)
                    .HasPrecision(3, 2);
        }
    }

}
