using MediatR;
using PartnerPortal.Application.Common.Exceptions;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Commands
{
    public record UpdateRequisitionFilesDetailsCommand : IRequest
    {
        public Guid RequisitionFileID { get; set; }
        
        public Guid RequisitionID { get; set; }
        public String FileName { get; set; }
        public String FileTypeDescription { get; set; }
    }
    public class UpdateRequisitionFilesDetailsCommandHandler : IRequestHandler<UpdateRequisitionFilesDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRequisitionFilesDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRequisitionFilesDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RequisitionFiles
                .FindAsync(new object[] { request.RequisitionFileID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RequisitionFile), request.RequisitionFileID);
            }

            entity.RequisitionID = request.RequisitionID;
            entity.FileName = request.FileName;
            entity.FileTypeDescription = request.FileTypeDescription;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
