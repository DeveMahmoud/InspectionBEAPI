using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InspectionVisit.Queries
{

    public class GetInspectionVisitByIdQueryHandler : IRequestHandler<GetInspectionVisitByIdQuery, InspectionVisitQueryDto>
    {
        private readonly IGenericRepository<Domain.Models.InspectionVisit> _repository;
        private readonly IMapper _mapper;

        public GetInspectionVisitByIdQueryHandler(IGenericRepository<Domain.Models.InspectionVisit> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<InspectionVisitQueryDto> Handle(GetInspectionVisitByIdQuery request, CancellationToken cancellationToken)
        {
            var visit = await _repository.GetByIdAsync(request.Id);

            if (visit == null)
                throw new KeyNotFoundException($"Inspection Visit with Id {request.Id} not found.");

            return _mapper.Map<InspectionVisitQueryDto>(visit);
        }
    }
}
