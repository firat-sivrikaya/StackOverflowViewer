using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class TagPostListModel
    {
        public string TagId { get; set; }
        public int PostId { get; set; }
        public IList<TagPostModel> TagPosts{ get; set; }
        public string Url { get; set; }

    }
}
