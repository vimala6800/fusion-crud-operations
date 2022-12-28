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
    public record UpdateProjectManagerDetailsCommand : IRequest
    {
        public Guid ProjectManagerID { get; set; }
        public string ProjectManagerName { get; set; }
        public string EmployeeID { get; set; }
        public string PMEmailID { get; set; }
    }
    public class UpdateProjectManagerDetailsCommandHandler : IRequestHandler<UpdateProjectManagerDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateProjectManagerDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateProjectManagerDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.ProjectManagers
                .FindAsync(new object[] { request.ProjectManagerID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectManager), request.ProjectManagerID);
            }

            entity.ProjectManagerName = request.ProjectManagerName;
            entity.EmployeeID = request.EmployeeID;
            entity.PMEmailID = request.PMEmailID;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
