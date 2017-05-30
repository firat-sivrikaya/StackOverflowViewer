using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class HistoryListModel
    {
        public int UserId { get; set; }
        public string  Statement{get; set; }

        public DateTime Creation{get; set;}

        public string Url {get; set;}

        //public string Body { get; set; }
        
    }
}
