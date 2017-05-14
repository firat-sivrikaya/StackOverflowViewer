using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;


namespace StackOverflowDatabase
{
        public class StackOverflowDataService : IPostDataService, IUserDataService, IMarkedPostDataService, ITagDataService,
        ITagPostDataService
        {
            public void CreateMarkedPost(MarkedPost post)
            {
                using (var contex = new StackOverflowContext())
                {
                    contex.MarkedPost.Add(post);
                    contex.SaveChanges();
                    //var nextId = contex.Categories.Max(x => x.Id) + 1;
                    //category.Id = nextId;
                    // Instead of this change the database to use auto increment on
                    // the categoryid in the category table.
                    // Note: that you need to remove the foreign key in product first, 
                    // then add the AI and finally reenter the FK on product.
                    
                    //contex.Categories.Add(category);
                    //contex.SaveChanges();
                }
            }

            public void DeleteMarkedPost(MarkedPost post)
            {
                using (var contex = new StackOverflowContext())
                {
                    contex.MarkedPost.Remove(post);
                    contex.SaveChanges();
                }
            }

            public IList<Post> GetPosts(int pageNumber, int pageSize)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Post
                        //.OrderBy(x => x.Name)
                        .Skip((pageNumber - 1) * pageSize)  // 
                        .Take(pageSize) // limit in db
                        .ToList();
                }
            }

            public IList<MarkedPost> GetMarkedPosts(int pageNumber, int pageSize)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.MarkedPost
                        //.OrderBy(x => x.Name)
                        .Skip((pageNumber - 1) * pageSize)  // 
                        .Take(pageSize) // limit in db
                        .ToList();
                }
            }            

            public MarkedPost GetMarkedPost(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.MarkedPost.Find(id);
                }
            }

            public TagPost GetTagOfPost(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.TagPost.Find(id);
                }
            }

            public Post GetPost(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Post.Find(id);
                }
            }

            public Tag GetTag(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Tag.Find(id);
                }
            }

            public IList<Tag> GetTags(int pageNumber, int pageSize)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Tag
                        //.OrderBy(x => x.Name)
                        .Skip((pageNumber - 1) * pageSize)  // 
                        .Take(pageSize) // limit in db
                        .ToList();
                }
            }

            public IList<TagPost> GetPostsByTag(int pageNumber, int pageSize)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.TagPost
                        //.OrderBy(x => x.Name)
                        .Skip((pageNumber - 1) * pageSize)  // 
                        .Take(pageSize) // limit in db
                        .ToList();
                }
            }   

            public int GetNumberOfPost()
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Post.Count();
                }
            }

            public int GetNumberOfTags()
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Tag.Count();
                }
            }
            public int GetNumberOfTagPosts()
            {
                using (var context = new StackOverflowContext())
                {
                    return context.TagPost.Count();
                }
            }                

            public int GetNumberOfMarkedPost()
            {
                using (var context = new StackOverflowContext())
                {
                    return context.MarkedPost.Count();
                }
            }            

            public void UpdateMarkedPost(MarkedPost post)
            {
                using (var contex = new StackOverflowContext())
                {
                    contex.MarkedPost.Update(post);
                    contex.SaveChanges();
                }
            }

            /*
            
            User related functions
            
             */
            public User GetUser(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.User.Find(id);
                }
            }

            public int GetNumberOfUsers()
            {
                using (var context = new StackOverflowContext())
                {
                    return context.User.Count();
                }
            }

            public IList<User> GetUsers(int pageNumber, int pageSize)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.User
                        //.OrderBy(x => x.Name)
                        .Skip((pageNumber - 1) * pageSize)  // 
                        .Take(pageSize) // limit in db
                        .ToList();
                }
            }
        
    }

}
