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
    public record UpdatePatnerDetailsCommand : IRequest
    {
        public Guid PartnerID { get; set; }
        public string PartnerName { get; set; }
        public object ProjectManagerID { get; internal set; }
    }
    public class UpdatePatnerDetailsCommandHandler : IRequestHandler<UpdatePatnerDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdatePatnerDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdatePatnerDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Partners
                .FindAsync(new object[] { request.PartnerID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Partner), request.PartnerID);
            }

            entity.PartnerName = request.PartnerName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

