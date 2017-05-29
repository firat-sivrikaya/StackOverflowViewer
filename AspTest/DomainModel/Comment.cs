using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Creation { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; } 
    }

}

