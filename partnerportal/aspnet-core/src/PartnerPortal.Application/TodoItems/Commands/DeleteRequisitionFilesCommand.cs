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
    public record DeleteRequisitionFilesCommand(Guid Id) : IRequest;
    public class DeleteRequisitionFilesCommandHandler : IRequestHandler<DeleteRequisitionFilesCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRequisitionFilesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRequisitionFilesCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RequisitionFiles
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RequisitionFile), request.Id);
            }

            _context.RequisitionFiles.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}


