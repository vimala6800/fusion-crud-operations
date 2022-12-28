using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class Skil
    {
        [Key]
        public Guid SkillID { get; set; }
        public string Skill { get; set; }
    }
}
