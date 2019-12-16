using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagementApp.Models.EntityFramework
{
    public class ManagementContext:DbContext
    {
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageGallery> ImageGalleries { get; set; }
        public ManagementContext():base("ManagementConStr")
        {
            Database.SetInitializer(new DataInitilaizer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonnelMap());
            modelBuilder.Configurations.Add(new DepartmentMap());
            modelBuilder.Configurations.Add(new UserMap());
            
        }
    }
}