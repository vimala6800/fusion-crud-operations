using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Commands
{
    public record UpdateSkillsDetailsCommand : IRequest
    {
        public Guid SkillID { get; set; }
        public string Skill { get; set; }
    }
    public class UpdateSkillsDetailsCommandHandler : IRequestHandler<UpdateSkillsDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateSkillsDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSkillsDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Skills
                .FindAsync(new object[] { request.SkillID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Skil), request.SkillID);
            }

            entity.Skill = request.Skill;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
