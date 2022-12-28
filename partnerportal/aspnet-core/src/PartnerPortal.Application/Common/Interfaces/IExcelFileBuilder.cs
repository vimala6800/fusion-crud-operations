using PartnerPortal.Application.TodoLists.Queries.ExportTodos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Common.Interfaces
{
    public interface IExcelFileBuilder
    {
        byte[] BuildRequisitionsFile(IEnumerable<RequisitionRecord> records);
    }
}
