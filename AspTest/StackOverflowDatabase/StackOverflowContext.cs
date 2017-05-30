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
        public DbSet<Comment> Comment {get; set;}
        public DbSet<Tag> Tag { get; set; }
        public DbSet<WordIdf> WordIdfs { get; set; }
        public DbSet<WordTf> WordTfs { get; set; }

        public DbSet<History> History{get;set;}
        //public DbSet<TagPost> TagPost {get; set;}

        public DbSet<MarkedPost> MarkedPost {get; set;}
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
            modelBuilder.Entity<Post>().Property(x => x.ClosedDate).HasColumnName("closeddate");
            modelBuilder.Entity<Post>().Property(x => x.PostTypeId).HasColumnName("posttypeid");
            modelBuilder.Entity<Post>().Property(x => x.AcceptedAnswerId).HasColumnName("acceptedanserid");
            modelBuilder.Entity<Post>().Property(x => x.OwnerId).HasColumnName("ownerid");
            // Build models for users
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>().Property(x => x.Id).HasColumnName("iduser");
            modelBuilder.Entity<User>().Property(x => x.DisplayedName).HasColumnName("displayedname");
            modelBuilder.Entity<User>().Property(x => x.CreationDate).HasColumnName("creationdate");
            modelBuilder.Entity<User>().Property(x => x.Age).HasColumnName("age");
            modelBuilder.Entity<User>().Property(x => x.Location).HasColumnName("location");
            // Build models for marked posts
            modelBuilder.Entity<MarkedPost>().ToTable("markedposts");
            modelBuilder.Entity<MarkedPost>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<MarkedPost>().Property(x => x.Notes).HasColumnName("notes");
            // Build models for tags
            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Tag>().Property(x => x.TagName).HasColumnName("tagname");
            modelBuilder.Entity<Tag>().Property(x => x.PostCount).HasColumnName("post_count");
            //History
            modelBuilder.Entity<History>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<History>().Property(x => x.Statement).HasColumnName("statement");
            modelBuilder.Entity<History>().Property(x => x.Creation).HasColumnName("_timestamp");
            // Build models for comments
            modelBuilder.Entity<Comment>().ToTable("comments");
            modelBuilder.Entity<Comment>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Comment>().Property(x => x.Score).HasColumnName("score");
            modelBuilder.Entity<Comment>().Property(x => x.Body).HasColumnName("body");
            modelBuilder.Entity<Comment>().Property(x => x.Creation).HasColumnName("creation");
            modelBuilder.Entity<Comment>().Property(x => x.UserId).HasColumnName("userid");
            modelBuilder.Entity<Comment>().Property(x => x.PostId).HasColumnName("postid");
            //Build dummy models for TFIDF
            modelBuilder.Entity<WordIdf>().ToTable("wordidfs");

            modelBuilder.Entity<WordTf>().ToTable("wordTfs").HasKey(pc => new { pc.Contentid, pc.Tf, pc.WordId });
            // Build models for tags posts
            //modelBuilder.Entity<TagPost>().ToTable("tags_post");
            //modelBuilder.Entity<TagPost>().Property(x => x.PostId).HasColumnName("postid");
            //modelBuilder.Entity<TagPost>().Property(x => x.TagId).HasColumnName("tagid");
        }
    }
}
