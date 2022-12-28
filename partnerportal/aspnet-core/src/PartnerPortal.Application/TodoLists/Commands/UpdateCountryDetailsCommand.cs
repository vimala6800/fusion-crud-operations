using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Commands
{
    public record UpdateCountryDetailsCommand : IRequest
    {
        
        public Guid CountryID { get; set; }
        public string CountryName { get; set; }
    }
    public class UpdateCountryDetailsCommandHandler : IRequestHandler<UpdateCountryDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateCountryDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateCountryDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Countries
                .FindAsync(new object[] { request.CountryID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Country), request.CountryID);
            }

            entity.CountryName = request.CountryName;
            
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
