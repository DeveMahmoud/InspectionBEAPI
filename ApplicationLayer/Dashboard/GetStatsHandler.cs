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
    public class GetStatsHandler: IRequestHandler<GetStatsQuery, StatsDto>
    {

        private readonly IGenericRepository<Domain.Models.InspectionVisit> _repository;
        private readonly IMapper _mapper;

        public GetStatsHandler(IGenericRepository<Domain.Models.InspectionVisit> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<StatsDto> Handle(GetStatsQuery request, CancellationToken cancellationToken)
        {
            var allVisits = await _repository.ListAsync();

            var stats = new StatsDto
            {
                Planned = allVisits.Count(v => v.Status == VisitStatus.Planned),
                InProgress = allVisits.Count(v => v.Status == VisitStatus.InProgress),
                Completed = allVisits.Count(v => v.Status == VisitStatus.Completed),
                Cancelled = allVisits.Count(v => v.Status == VisitStatus.Cancelled)
            };

            return _mapper.Map<StatsDto>(stats);
        }

    }
    
}
