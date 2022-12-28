using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Domain.Entities
{
    public class ProjectManager
    {
        public Guid ProjectManagerID { get; set; }
        public string ProjectManagerName { get; set; }
        public string EmployeeID { get; set; }
        public string PMEmailID { get; set; }
    }
}
