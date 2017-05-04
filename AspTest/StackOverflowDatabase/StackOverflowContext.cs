using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DomainModel;

namespace StackOverflowDatabase
{
    public class StackOverflowContext : DbContext
    {
        public DbSet<Post> Post { get; set; }
        public DbSet<User> User { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            // Modify database info in order to run it in your own environment
            optionsBuilder.UseMySql("server=localhost;database=testmigration;uid=root;pwd=pass");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>().Property(x => x.Id).HasColumnName("idpost");
            modelBuilder.Entity<Post>().Property(x => x.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<Post>().Property(x => x.Score).HasColumnName("score");
            modelBuilder.Entity<Post>().Property(x => x.Body).HasColumnName("body");
            modelBuilder.Entity<Post>().Property(x => x.Title).HasColumnName("title");
            //modelBuilder.Entity<Post>().Property(x => x.ClosedDate).HasColumnName("closeddate");
            modelBuilder.Entity<Post>().Property(x => x.PostTypeId).HasColumnName("posttypeid");
            //modelBuilder.Entity<Post>().Property(x => x.AcceptedAnswerId).HasColumnName("acceptedanserid");
            modelBuilder.Entity<Post>().Property(x => x.OwnerId).HasColumnName("ownerid");
            // Build models for users
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("iduser");
            modelBuilder.Entity<User>().Property(x => x.DisplayedName).HasColumnName("displayedname");
            modelBuilder.Entity<User>().Property(x => x.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<User>().Property(x => x.Age).HasColumnName("age");
            modelBuilder.Entity<User>().Property(x => x.Location).HasColumnName("location");
        }
    }
}
