using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class CommentModel : CommentListModel
    {
        public Nullable<DateTime> Creation { get; set; }
        public int Score { get; set; }
        public string UserName {get; set;}

    }
}
