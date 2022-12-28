using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class Partner
    {
        [Key]
        public Guid PartnerID { get; set; }
        public string PartnerName { get; set; }
    }
}
