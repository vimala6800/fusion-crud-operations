using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.Dummy.Commands
{
    public record CreateProjectManagerCommand : IRequest<int>
    {
        public Guid ProjectManagerID { get; set; }
        public string ProjectManagerName { get; set; }
        public string EmployeeID { get; set; }
        public string PMEmailID { get; set; }
    }

    public class CreateProjectManagerCommandHandler : IRequestHandler<CreateProjectManagerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProjectManagerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProjectManagerCommand request, CancellationToken cancellationToken)
        {
            var entity = new ProjectManager
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                ProjectManagerName = request.ProjectManagerName,
                EmployeeID = request.EmployeeID,
                PMEmailID = request.PMEmailID

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.ProjectManagers.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}
