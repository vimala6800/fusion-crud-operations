using PartnerPortal.Application.Common.Mappings;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Queries.ExportTodos
{
    public class RequisitionRecord : IMapFrom<Requisition>
    {
        public Guid RequisitionID { get; set; }
        public string RequisitionCode { get; set; }
        public string PotentialNumber { get; set; }
        public string Complexity { get; set; }
        public DateTime RequisitionDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public String ClientName { get; set; }
        public Guid ClientCountreyID { get; set; }
        public String ProjectType { get; set; }
        public Byte RequisitionStatus { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public Double Budget { get; set; }
        public Guid DepartmentID { get; set; }
        public Guid CurrencyID { get; set; }
        public string? ProjectDescription { get; set; }

        public IList<RequisitionFile> RequisitionFiles { get; private set; } = new List<RequisitionFile>();
        public IList<RequisitionJD> RequisitionJDs { get; private set; } = new List<RequisitionJD>();
        public IList<RequisitionSkill> RequisitionSkills { get; private set; } = new List<RequisitionSkill>();
        public IList<RequisitionPartner> RequisitionPartners { get; private set; } = new List<RequisitionPartner>();
    }
}
