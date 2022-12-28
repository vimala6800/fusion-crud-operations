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
    public record CreateCountryCommand : IRequest<int>
    {
        public Guid CountryID { get; set; }
        public string CountryName { get; set; }
    }

    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCountryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var entity = new Country
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                CountryName = request.CountryName,

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.Countries.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}
