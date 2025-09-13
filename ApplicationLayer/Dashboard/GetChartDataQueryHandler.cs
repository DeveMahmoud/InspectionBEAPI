using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dashboard
{
    public class GetChartDataQueryHandler : IRequestHandler<GetChartDataQuery, ChartDataDto>
    {
        private readonly IGenericRepository<Domain.Models.EntityToInspect> _entityRepository;
        private readonly IGenericRepository<Domain.Models.InspectionVisit> _visitRepository;
        private readonly IMapper _mapper;

        public GetChartDataQueryHandler(
            IGenericRepository<Domain.Models.EntityToInspect> entityRepository,
            IGenericRepository<Domain.Models.InspectionVisit> visitRepository,
            IMapper mapper)
        {
            _entityRepository = entityRepository;
            _visitRepository = visitRepository;
            _mapper = mapper;
        }

        public async Task<ChartDataDto> Handle(GetChartDataQuery request, CancellationToken cancellationToken)
        {
            var entities = await _entityRepository.ListAsync();
            var visits = await _visitRepository.ListAsync();

            var grouped = entities
                .GroupJoin(visits,
                    entity => entity.Id,
                    visit => visit.EntityToInspectId,
                    (entity, entityVisits) => new
                    {
                        entity.Category,
                        VisitCount = entityVisits.Count()
                    })
                .GroupBy(x => x.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Sum(x => x.VisitCount)
                })
                .ToList();

            return new ChartDataDto
            {
                Labels = grouped.Select(g => g.Category).ToList(),
                Values = grouped.Select(g => g.Count).ToList()
            };
        }
    }
}
