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
    public record DeleteRequisitionSkillCommand(Guid Id) : IRequest;
    public class DeleteRequisitionSkillCommandHandler : IRequestHandler<DeleteRequisitionSkillCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteRequisitionSkillCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRequisitionSkillCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Skills
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RequisitionSkill), request.Id);
            }

            _context.Skills.Remove(entity);

            //entity.AddDomainEvent(new TodoItemDeletedEvent(entity));

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
