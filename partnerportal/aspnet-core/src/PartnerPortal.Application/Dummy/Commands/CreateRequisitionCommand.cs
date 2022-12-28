using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Dummy.Commands
{
    public record CreateRequisitionCommand : IRequest<int>
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
    }

    public class CreateRequisitionCommandHandler : IRequestHandler<CreateRequisitionCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateRequisitionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRequisitionCommand request, CancellationToken cancellationToken)
        {
            var entity = new Requisition
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                RequisitionCode = request.RequisitionCode,
                PotentialNumber = request.PotentialNumber,
                Complexity = request.Complexity,
                RequisitionDate = request.RequisitionDate,
                DeadlineDate = request.DeadlineDate,
                ClientName = request.ClientName,
                ClientCountreyID = request.ClientCountreyID,
                ProjectType = request.ProjectType,
                ExpectedStartDate = request.ExpectedStartDate,
                Budget = request.Budget,
                DepartmentID = request.DepartmentID,
                CurrencyID = request.CurrencyID,
                ProjectDescription = request.ProjectDescription,

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.Requisitions.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}
