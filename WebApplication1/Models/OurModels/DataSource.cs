using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models.OurModels
{
    public partial class DataSource : DbContext
    {
        public DataSource()
            : base("name=DataSource")
        {
        }

        public virtual DbSet<College> Colleges { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<College>()
                .Property(e => e.CollegeName)
                .IsUnicode(false);

            modelBuilder.Entity<College>()
                .HasMany(e => e.Students)
                .WithRequired(e => e.College)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.FIrstName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
