using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class HistoryModel : HistoryListModel
    {
        public int UserId{get; set;}
        public string Statement{get; set;}
    }
}
