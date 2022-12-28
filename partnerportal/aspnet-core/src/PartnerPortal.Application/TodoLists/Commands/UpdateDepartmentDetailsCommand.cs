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
    public record UpdateDepartmentDetailsCommand : IRequest
    {
        public Guid DepartmentID { get; set; }
        public string DepartmentName { get; set; }
    }
    public class UpdateDepartmentDetailsCommandHandler : IRequestHandler<UpdateDepartmentDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateDepartmentDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateDepartmentDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Departments
                .FindAsync(new object[] { request.DepartmentID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Department), request.DepartmentID);
            }

            entity.DepartmentName = request.DepartmentName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
