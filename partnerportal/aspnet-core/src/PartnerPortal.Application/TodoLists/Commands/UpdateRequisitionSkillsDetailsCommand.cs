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
    public record UpdateRequisitionSkillsDetailsCommand : IRequest
    {
        public Guid RequisitionSkillID { get; set; }
        public Guid RequisitionID { get; set; }
       
        public Guid SkillID { get; set; }
        
        public Byte Mandatory { get; set; }
        public int Experience { get; set; }
        public string Comments { get; set; }
    }
    public class UpdateRequisitionSkillsDetailsCommandHandler : IRequestHandler<UpdateRequisitionSkillsDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRequisitionSkillsDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRequisitionSkillsDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RequisitionSkills
                .FindAsync(new object[] { request.RequisitionSkillID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RequisitionSkill), request.RequisitionSkillID);
            }

            entity.RequisitionID = request.RequisitionID;
            entity.SkillID = request.SkillID;
            entity.Mandatory = request.Mandatory;
            entity.Experience = request.Experience;
            entity.Comments = request.Comments;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
