using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class TagPostModel : TagPostListModel
    {
        public int PostId { get; set; }
        public int TagId { get; set; }
        public string Url {get; set;}

        //public IList<PostModel> TagPosts{ get; set; }
    }
}
