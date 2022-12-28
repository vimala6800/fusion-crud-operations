using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoItems.Commands
{
    public record DeleteRequisitionPatnerCommand(Guid Id) : IRequest;
    public class DeleteRequisitionPatnerCommandHandler : IRequestHandler<DeleteRequisitionPatnerCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRequisitionPatnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRequisitionPatnerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RequisitionPartners
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RequisitionJD), request.Id);
            }

            _context.RequisitionPartners.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

