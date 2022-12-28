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
    public record DeleteCountriesCommand (Guid Id) : IRequest;
    public class DeleteCountriesCommandHandler : IRequestHandler<DeleteCountriesCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCountriesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCountriesCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country), request.Id);
            }

            _context.Countries.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
