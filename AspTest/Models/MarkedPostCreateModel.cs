using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebService.Models
{
    public class MarkedPostCreateOrUpdateModel : MarkedPostModel
    {
        public int Id { get; set; }
        public string Notes { get; set; }
    }
}
