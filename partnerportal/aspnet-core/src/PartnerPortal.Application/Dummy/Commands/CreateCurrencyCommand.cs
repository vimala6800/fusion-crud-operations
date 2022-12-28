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
    public record CreateCurrencyCommand : IRequest<int>
    {
        public Guid CurrencyID { get; set; }
        public string CurrencyName { get; set; }
    }

    public class CreateCurrencyCommandHandler : IRequestHandler<CreateCurrencyCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateCurrencyCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCurrencyCommand request, CancellationToken cancellationToken)
        {
            var entity = new Currency
            {
                //SalesPersonId = request.((SalesPersonId).ToString()),
                CurrencyName = request.CurrencyName,

            };

            //entity.AddDomainEvent(new SalesPersonCreatedEvent(entity));

            _context.Currencies.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            //return request.DepartmentID;
            return 1;

        }
    }
}
