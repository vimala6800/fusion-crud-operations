using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class SalesPerson
    {
        [Key]
        public Guid SalesPersonId { get; set; }
        public string? SalesPersonName { get; set; }
        public string? Email { get; set; }
        public string Company { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
    }
}
