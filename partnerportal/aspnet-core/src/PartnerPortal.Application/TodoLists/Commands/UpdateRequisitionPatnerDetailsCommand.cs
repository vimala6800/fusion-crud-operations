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
    public record UpdateRequisitionPatnerDetailsCommand : IRequest
    {
        public Guid RequsitionPartnerID { get; set; }
        public Guid RequestionID { get; set; }
        
        public Guid PartnerId { get; set; }
        
    }
    public class UpdateRequisitionPatnerDetailsCommandHandler : IRequestHandler<UpdateRequisitionPatnerDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRequisitionPatnerDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRequisitionPatnerDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RequisitionPartners
                .FindAsync(new object[] { request.RequsitionPartnerID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RequisitionPartner), request.RequsitionPartnerID);
            }

            entity.RequestionID = request.RequestionID;
            entity.PartnerId= request.PartnerId;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
