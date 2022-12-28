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
    public record CreateDepartmentCommand : IRequest<int>
    {
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateDepartmentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Department
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                DepartmentName = request.DepartmentName,

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.Departments.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}
