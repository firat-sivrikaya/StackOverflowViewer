using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel
{
    public class Search
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int Score { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public Nullable<DateTime> ClosedDate { get; set; }
        public int PostTypeId { get; set; }
        public Nullable<int> AcceptedAnswerId { get; set; }
        public int OwnerId { get; set; }

    }
}
