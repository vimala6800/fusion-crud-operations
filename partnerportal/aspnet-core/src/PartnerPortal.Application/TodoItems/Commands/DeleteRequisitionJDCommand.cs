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
    public record DeleteRequisitionJDCommand(Guid Id) : IRequest;
    public class DeleteRequisitionJDDetailsCommandHandler : IRequestHandler<DeleteRequisitionJDCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRequisitionJDDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRequisitionJDCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RequisitionJDs
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RequisitionJD), request.Id);
            }

            _context.RequisitionJDs.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}


