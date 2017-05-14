using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class MarkedPostListModel
    {
        public int Id { get; set; }
        public string PostId { get; set; }
        public string Notes {get; set; }

        //public string Body { get; set; }
        
    }
}
