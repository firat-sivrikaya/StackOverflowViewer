using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }

        public int PostCount { get; set; }
    }
}
