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
    public record DeleteSkillsCommand(Guid Id) : IRequest;
    public class DeleteSkillsCommandHandler : IRequestHandler<DeleteSkillsCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteSkillsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSkillsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Skills
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Skil), request.Id);
            }

            _context.Skills.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
