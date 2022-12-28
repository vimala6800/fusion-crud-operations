using CsvHelper;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.TodoLists.Queries.ExportTodos;
using PartnerPortal.Infrastructure.Files.Maps;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Infrastructure.Files
{
    public class ExcelFileBuilder : IExcelFileBuilder
    {
        public byte[] BuildRequisitionsFile(IEnumerable<RequisitionRecord> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Configuration.RegisterClassMap<RequisitionRecordMap>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
    }
}
