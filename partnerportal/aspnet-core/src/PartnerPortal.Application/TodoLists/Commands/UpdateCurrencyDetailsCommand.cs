using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Application.TodoLists.Commands;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Commands
{
    public record UpdateCurrencyDetailsCommand : IRequest
    {

        public Guid CurrencyID { get; set; }
        public string CurrencyName { get; set; }
    }
    public class UpdateCurrencyDetailsCommandHandler : IRequestHandler<UpdateCurrencyDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCurrencyDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCurrencyDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Currencies
                .FindAsync(new object[] { request.CurrencyID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Currency), request.CurrencyID);
            }

            entity.CurrencyName = request.CurrencyName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}


   