using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Violation.Queries
{
    public class GetViolationByIdQueryHandler : IRequestHandler<GetViolationByIdQuery, ViolationDto>
    {
        private readonly IGenericRepository<Domain.Models.Violation> _violationRepository;
        private readonly IMapper _mapper;

        public GetViolationByIdQueryHandler(IGenericRepository<Domain.Models.Violation> violationRepository, IMapper mapper)
        {
            _violationRepository = violationRepository;
            _mapper = mapper;
        }

        public async Task<ViolationDto> Handle(GetViolationByIdQuery request, CancellationToken cancellationToken)
        {
            var violation = await _violationRepository.GetByIdAsync(request.Id);
            var violationDto = new ViolationDto
            {
                Id = violation.Id,
                InspectionVisitId = violation.InspectionVisitId,
                Code = violation.Code,
                Description = violation.Description,
                Severity = violation.Severity
            };
            return violationDto;
            //return _mapper.Map<ViolationDto>(violation);
        }
    }
}
