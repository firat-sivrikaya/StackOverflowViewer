using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    [Table("wordtf")]
    public class WordTf
    {

        public int Contentid { get; set; }

        public string What { get; set; }

        public int WordId { get; set; }

        public float Tf { get; set; }

    }
}