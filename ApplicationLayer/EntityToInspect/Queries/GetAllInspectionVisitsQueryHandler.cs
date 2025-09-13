using ApplicationLayer.DTO;
using ApplicationLayer.InspectionVisit.Queries;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityToInspect.Queries
{
    public class GetAllInspectionVisitsQueryHandler : IRequestHandler<GetAllInspectionVisitsQuery, List<InspectionVisitQueryDto>>
    {
        private readonly IGenericRepository<Domain.Models.InspectionVisit> _repository;
        private readonly IMapper _mapper;
        public GetAllInspectionVisitsQueryHandler(
            IGenericRepository<Domain.Models.InspectionVisit> repository,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<List<InspectionVisitQueryDto>> Handle(GetAllInspectionVisitsQuery request, CancellationToken cancellationToken)
        {
            var visits = await _repository.ListAsync();

            return _mapper.Map<List<InspectionVisitQueryDto>>(visits);
        }
    }
}
