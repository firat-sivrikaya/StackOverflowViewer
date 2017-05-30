using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;


namespace StackOverflowDatabase
{
        public class StackOverflowDataService : IPostDataService, IUserDataService, IMarkedPostDataService, ITagDataService, ICommentDataService
        {
             public WordIdf GetIDFOfWord(string word)
            {
                using (var db = new StackOverflowContext())
                {
                return db.WordIdfs.Where(w => w.Word == word).First();
                }
            }

            public List<WordTf> GetTFsOfWord(int wordId)
            {
                using (var db = new StackOverflowContext())
                {
                    return db.WordTfs.Where(w => w.WordId == wordId).ToList();
                }
            }
             public void CreateHistory(History hist)
            {
                using (var context = new StackOverflowContext())
                {
                    context.History.Add(hist);
                    context.SaveChanges();
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

            public void DeleteHistory(History hist)
            {
                using (var contex = new StackOverflowContext())
                {
                    contex.History.Remove(hist);
                    contex.SaveChanges();
                }
            }
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

            public IList<Comment> GetComments(int pageNumber, int pageSize)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Comment
                        //.OrderBy(x => x.Name)
                        .Skip((pageNumber - 1) * pageSize)  // 
                        .Take(pageSize) // limit in db
                        .ToList();
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
            public IList<History> GetHisotry(int pageNumber, int pageSize)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.History
                        //.OrderBy(x => x.Name)
                        .Skip((pageNumber - 1) * pageSize)  // 
                        .Take(pageSize) // limit in db
                        .ToList();
                }
            }  

            public History GetHistory(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.History.Find(id);
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
            public int GetNumberOfHisotry()
            {
                using (var context = new StackOverflowContext())
                {
                    return context.History.Count();
                }
            }            

            public MarkedPost GetMarkedPost(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.MarkedPost.Find(id);
                }
            }
            /* 
            public TagPost GetTagOfPost(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.TagPost.Find(id);
                }
            }*/

            public Comment GetComment(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Comment.Find(id);
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
                        .OrderByDescending(x => x.PostCount)
                        .Skip((pageNumber - 1) * pageSize)  // 
                        .Take(pageSize) // limit in db
                        .ToList();
                }
            }

            /* 
            public IList<Post> GetPostsByTag(int pageNumber, int pageSize)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Post.Skip((pageNumber
                     - 1) * pageSize).Take(pageSize).Where(context.Post.).ToList();
                }
            }*/

            /* 
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
            }   */
            public int GetNumberOfComment()
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Comment.Count();
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
            /* 
            public int GetNumberOfTagPosts()
            {
                using (var context = new StackOverflowContext())
                {
                    return context.TagPost.Count();
                }
            } */             

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
