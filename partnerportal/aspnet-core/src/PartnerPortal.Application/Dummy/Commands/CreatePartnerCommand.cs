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
    public record CreatePartnerCommand : IRequest<int>
    {
        public Guid PartnerID { get; set; }
        public string PartnerName { get; set; }
    }

    public class CreatePartnerCommandHandler : IRequestHandler<CreatePartnerCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePartnerCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePartnerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Partner
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                PartnerName = request.PartnerName,

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.Partners.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}
