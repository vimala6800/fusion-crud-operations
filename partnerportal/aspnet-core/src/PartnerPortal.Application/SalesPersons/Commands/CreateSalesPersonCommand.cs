using MediatR;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.SalesPersons.Commands
{
    public record CreateSalesPersonCommand : IRequest<int>
    {
        public int SalesPersonId { get; set; }
        public string? SalesPersonName { get; set; }
        public string? Email { get; set; }
        public string Company { get; set; }
        public string? Address { get; set; }
        public string? Contact { get; set; }
    }

    public class CreateSalesPersonCommandHandler : IRequestHandler<CreateSalesPersonCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateSalesPersonCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateSalesPersonCommand request, CancellationToken cancellationToken)
        {
            var entity = new SalesPerson
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                SalesPersonName = request.SalesPersonName,
                Email = request.Email,
                Company = request.Company,
                Address = request.Address,
                Contact = request.Contact,

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.SalesPersons.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.SalesPersonName;
            return 1;
        }
    }
}
