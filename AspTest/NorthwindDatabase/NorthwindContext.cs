using Microsoft.EntityFrameworkCore;
using DomainModel; 
 
 namespace NorthwindDatabase
 {
     public class NorthwindContex : DbContext
     {
         public DbSet<Category> Categories {get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             base.OnConfiguring(optionsBuilder);
             optionsBuilder.UseMySql("server=localhost;database=northwind;uid=root;pwd=pass");
         }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);
             modelBuilder.Entity<Category>().ToTable("category");
             modelBuilder.Entity<Category>().Property(x => x.Id).HasColumnName("categoryid");
             modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
         }
     }
 }