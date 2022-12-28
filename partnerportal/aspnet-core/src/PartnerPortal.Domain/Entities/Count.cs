using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class Count
    {
        [Key]
        public Guid CountryID { get; set; }
        public string CountryName { get; set; }

    }
}
