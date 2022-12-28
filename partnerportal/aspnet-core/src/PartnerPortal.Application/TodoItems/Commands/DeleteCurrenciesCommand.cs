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
    public record DeleteCurrenciesCommand(Guid Id) : IRequest;
    public class DeleteCurrenciesCommandHandler : IRequestHandler<DeleteCurrenciesCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCurrenciesCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCurrenciesCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Currencies
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Currency), request.Id);
            }

            _context.Currencies.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

