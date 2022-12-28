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
    public record UpdateRequisitionJDDetailsCommand : IRequest
    {
        public Guid RequisitionJDID { get; set; }
        public Guid RequisitionID { get; set; }
        
        public string JobDescription { get; set; }
        public int Duration { get; set; }
        public string DurationUnits { get; set; }
        public string ShiftTimings { get; set; }
        public int NoOfResources { get; set; }
        public int OpenPositions { get; set; }
        public String KeyDescription { get; set; }
        public string PreferredEducation { get; set; }
        public int MinExperience { get; set; }
        public int MaxExperience { get; set; }
        public string JDFileName { get; set; }
    }
    public class UpdateRequisitionJDDetailsCommandHandler : IRequestHandler<UpdateRequisitionJDDetailsCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRequisitionJDDetailsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRequisitionJDDetailsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.RequisitionJDs
                .FindAsync(new object[] { request.RequisitionJDID }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(RequisitionJD), request.RequisitionJDID);
            }

            entity.RequisitionID = request.RequisitionID;
            entity.JobDescription = request.JobDescription;
            entity.Duration = request.Duration;
            entity.DurationUnits = request.DurationUnits;
            entity.ShiftTimings = request.ShiftTimings;
            entity.NoOfResources = request.NoOfResources;
            entity.OpenPositions = request.OpenPositions;
            entity.KeyDescription = request.KeyDescription;
            entity.PreferredEducation = request.PreferredEducation;
            entity.MinExperience = request.MinExperience;
            entity.MaxExperience = request.MaxExperience;
            entity.JDFileName = request.JDFileName;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
