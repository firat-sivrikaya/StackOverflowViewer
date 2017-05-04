using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class User
    {
        public int Id { get; set; }
        public string DisplayedName { get; set; }
        public DateTime CreationDate { get; set; }
        public string Location { get; set; }
        public int Age { get; set; }
    }
}
