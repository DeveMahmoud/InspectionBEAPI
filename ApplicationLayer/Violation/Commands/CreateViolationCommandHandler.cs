using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Violation.Commands
{
    public class CreateViolationCommandHandler : IRequestHandler<CreateViolationCommand, int>
    {
        private readonly IGenericRepository<Domain.Models.Violation> _violationRepository;
        private readonly IMapper _mapper;

        public CreateViolationCommandHandler(IGenericRepository<Domain.Models.Violation> violationRepository, IMapper mapper)
        {
            _violationRepository = violationRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateViolationCommand request, CancellationToken cancellationToken)
        {
            // Map from Command to Entity
            var violation = _mapper.Map<Domain.Models.Violation>(request);

            await _violationRepository.AddAsync(violation);
            await _violationRepository.SaveChangesAsync();

            return violation.Id;
        }
    }
}
