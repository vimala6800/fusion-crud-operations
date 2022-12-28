using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Commands
{
    public record UpdateRequisitionCommand : IRequest
    {
        public Guid RequisitionID { get; set; }
        public string RequisitionCode { get; set; }
        public string PotentialNumber { get; set; }
        public string Complexity { get; set; } 
        public DateTime RequisitionDate { get; set; }
        public DateTime DeadlineDate { get; set; }
        public String ClientName { get; set; }
        public String ProjectType { get; set; }
        public Byte RequisitionStatus { get; set; }
        public DateTime ExpectedStartDate { get; set; }
        public Double Budget { get; set; }
        public string? ProjectDescription { get; set; }

    }

    public class UpdateRequisitionCommandHandler : IRequestHandler<UpdateRequisitionCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRequisitionCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRequisitionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Requisitions
                .FindAsync(new object[] { request.RequisitionID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Requisition), request.RequisitionID);
            }

            //entity.Title = request.RequisitionCode;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
