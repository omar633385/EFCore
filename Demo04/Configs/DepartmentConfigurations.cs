using Demo04.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo04.Configs
{
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.DeptId);
            builder.Property(d => d.DeptName).HasMaxLength(50);
            builder.Property(d => d.CreationDate).HasDefaultValueSql("GetDate()");
            builder.Property(d=>d.Description).HasMaxLength(50).IsRequired(false);
            builder.OwnsOne(d => d.Address);

            builder.HasOne(d => d.Manager)
                .WithOne(e=>e.ManagedDepartment)
                .HasForeignKey<Department>(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
