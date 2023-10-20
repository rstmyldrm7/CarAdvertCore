using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAdvertCore.Domain.Entities
{
    public class Visit
    {
        public Guid ID { get; set; }
        public long advertId { get; set; }
        public string iPAdress { get; set; }
        public DateTime visitDate { get; set; }
    }
}
