using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class History
    {
        public int UserId { get; set; }
        public Nullable<DateTime> Creation { get; set; }
        public string Statement { get; set; }
       
    }

}

