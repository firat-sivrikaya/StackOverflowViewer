using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class MarkedPostModel : MarkedPostListModel
    {
        public int Id{get; set;}
        public string Notes{get; set;}
    }
}
