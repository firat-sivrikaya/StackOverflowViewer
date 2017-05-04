using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class UserModel : UserListModel
    {
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
    }
}
