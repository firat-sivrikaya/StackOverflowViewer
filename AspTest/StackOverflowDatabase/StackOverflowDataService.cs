using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DomainModel;


namespace StackOverflowDatabase
{
        public class StackOverflowDataService : IMyDataService
        {
            public void CreatePost(Post post)
            {
                using (var contex = new StackOverflowContext())
                {
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

            public void DeletePost(Post post)
            {
                using (var contex = new StackOverflowContext())
                {
                    contex.Post.Remove(post);
                    contex.SaveChanges();
                }
            }

            public IList<Post> GetPost(int pageNumber, int pageSize)
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

            public Post GetPost(int id)
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Post.Find(id);
                }
            }

            public int GetNumberOfPost()
            {
                using (var context = new StackOverflowContext())
                {
                    return context.Post.Count();
                }
            }

            public void UpdatePost(Post post)
            {
                using (var contex = new StackOverflowContext())
                {
                    contex.Post.Update(post);
                    contex.SaveChanges();
                }
            }
        
    }

}
