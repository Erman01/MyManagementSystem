using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.HasKey(x => x.Id);
            this.Property(x => x.Name).IsRequired().HasMaxLength(50);
            this.Property(x => x.Password).IsRequired().HasMaxLength(50);
            this.Property(x => x.Role).IsRequired().HasMaxLength(2);
            this.ToTable("User");
        }
    }
}