using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class CommentListModel
    {
        public int Id { get; set; }
        public string UserName {get; set;}
        public string Body { get; set; }
        public int PostId {get; set; }
        public int UserId {get; set; }
        public string Url {get; set; }
        //public string Body { get; set; }
        
    }
}
