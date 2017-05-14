using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class MarkedPost
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Notes { get; set; }
    }
}
