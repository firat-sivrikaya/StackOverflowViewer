using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class TagModel : TagListModel
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public IList<PostModel> TagPosts{ get; set; }
    }
}
