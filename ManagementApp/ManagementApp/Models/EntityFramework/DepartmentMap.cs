using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class DepartmentMap:EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.DepartmentName).HasMaxLength(50);
            this.ToTable("Department");
        }
    }
}