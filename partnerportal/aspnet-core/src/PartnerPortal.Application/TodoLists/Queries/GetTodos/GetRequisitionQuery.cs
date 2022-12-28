using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PartnerPortal.Application.Common.Interfaces;
using PartnerPortal.Domain.Entities;
using PartnerPortal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartnerPortal.Application.TodoLists.Queries.GetTodos
{
    public record GetRequisitionQuery : IRequest<RequisitionVm>;

    public class GetRequisitionQueryHandler : IRequestHandler<GetRequisitionQuery, RequisitionVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRequisitionQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RequisitionVm> Handle(GetRequisitionQuery request, CancellationToken cancellationToken)
        {
            return new RequisitionVm
            {
                //PriorityLevels = Enum.GetValues(typeof(PriorityLevel))
                //    .Cast<PriorityLevel>()
                //    .Select(p => new PriorityLevelDto { Value = (int)p, Name = p.ToString() })
                //    .ToList(),

                Lists = await _context.Requisitions
                    .AsNoTracking()
                    .ProjectTo<RequisitionDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.ClientName)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
