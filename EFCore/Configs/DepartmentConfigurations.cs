using EFCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Configs
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasOne(d => d.Manager)
                    .WithOne(I => I.ManagedDepartment)
                    .HasForeignKey<Department>(d => d.Ins_Id);


            builder.HasMany<Instructor>()
                    .WithOne(i => i.Department)
                    .HasForeignKey(i => i.Dept_Id)
                    .IsRequired(false);
        }
    }
}
