using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    [Table("wordidf")]
    public class WordIdf
    {
        [Key]
        public int WordId { get; set; }

        public string Word { get; set; }

        public float TotalIdf { get; set; }

        


    }
}