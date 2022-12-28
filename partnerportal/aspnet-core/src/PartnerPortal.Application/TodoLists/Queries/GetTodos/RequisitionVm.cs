using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Queries.GetTodos
{
    public class RequisitionVm
    {
        public IList<RequisitionDto> Lists { get; set; } = new List<RequisitionDto>();
    }
}
