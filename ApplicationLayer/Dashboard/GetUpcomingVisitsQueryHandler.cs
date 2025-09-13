using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using AutoMapper;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dashboard
{
    public class GetUpcomingVisitsQueryHandler : IRequestHandler<GetUpcomingVisitsQuery, List<UpcomingVisitDto>>
    {
        private readonly IGenericRepository<Domain.Models.InspectionVisit> _visitRepository;
        private readonly IMapper _mapper;

        public GetUpcomingVisitsQueryHandler(IGenericRepository<Domain.Models.InspectionVisit> visitRepository, IMapper mapper)
        {
            _visitRepository = visitRepository;
            _mapper = mapper;
        }
        public async Task<List<UpcomingVisitDto>> Handle(GetUpcomingVisitsQuery request, CancellationToken cancellationToken)
        {
            var visits = await _visitRepository.FindAsync(v =>
                v.ScheduledAt > DateTime.Now && v.Status == VisitStatus.Planned);

            var upcoming = visits
                .OrderBy(v => v.ScheduledAt)
                .Take(5)
                .Select(v => new UpcomingVisitDto
                {
                    EntityName = v.EntityToInspect?.Name ?? string.Empty,
                    InspectorName = v.Inspector?.FullName ?? string.Empty,
                    ScheduledAt = v.ScheduledAt
                })
                .ToList();

            return upcoming;
        }
    }
}
