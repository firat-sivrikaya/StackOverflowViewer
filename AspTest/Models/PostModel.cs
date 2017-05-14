using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class PostModel : PostListModel
    {
        public Nullable<DateTime> closedDate { get; set; }
        public int PostTypeId { get; set; }
        public Nullable<int> AcceptedAnswerId { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public TagModel Tag{ get; set; }
        public string TagUrl{ get; set; }
    }
}
