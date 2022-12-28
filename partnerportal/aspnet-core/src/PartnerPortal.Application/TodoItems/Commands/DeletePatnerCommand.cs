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
    public record DeletePatnerCommand(Guid Id) : IRequest;
    public class DeletePatnerCommandHandler : IRequestHandler<DeletePatnerCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePatnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePatnerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Partners
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Partner), request.Id);
            }

            _context.Partners.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
