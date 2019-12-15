using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class PersonnelMap:EntityTypeConfiguration<Personnel>
    {
        public PersonnelMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.FirstName).HasMaxLength(50);
            this.Property(x => x.LastName).HasMaxLength(50);
            this.ToTable("Personnel");
        }
    }
}