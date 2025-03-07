using Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.configs
{
    internal class DepartmentConfigs : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> d)
        { 
            d.HasKey(d => d.DeptId);
            d.Property(d => d.DeptId).UseIdentityColumn(10, 10);

            //d.Property(d => d.DeptId).HasDefaultValueSql("NewGuid()");
            //d.Property(d => d.DeptId).HasDefaultValue("10");

            //d.Property(d=>d.DeptId).ValueGeneratedNever();//disable identity

            d.Property(d => d.DeptName)
            .HasColumnName("Department Name")
            .HasColumnType("varchar(50)").HasMaxLength(20)
            .IsRequired(false).HasDefaultValue("HR")
            .HasAnnotation("MaxLength", 20);




            d.Property(d => d.CreationDate)
            .IsRequired()
            //.HasDefaultValue(DateTime.Now);//sets Time of Migration created
            .HasDefaultValueSql("GetDate()"); //stay the same after insert [can be set manually] [creation date]
            //.HasComputedColumnSql("GetDate()"); //recalculated automatically [not manually set] [Updated date]

            d.Ignore(d => d.Description); //like [NotMapped]

        }
    }
}
