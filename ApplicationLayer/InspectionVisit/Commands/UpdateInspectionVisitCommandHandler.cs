using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InspectionVisit.Commands
{
    public class UpdateInspectionVisitCommandHandler : IRequestHandler<UpdateInspectionVisitCommand, bool>
    {
        private readonly IGenericRepository<Domain.Models.InspectionVisit> _repository;
        private readonly IMapper _mapper;

        public UpdateInspectionVisitCommandHandler(
            IGenericRepository<Domain.Models.InspectionVisit> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<bool> Handle(UpdateInspectionVisitCommand request, CancellationToken cancellationToken)
        {
            var existingVisit = await _repository.GetByIdAsync(request.Id);
            if (existingVisit == null)
                throw new KeyNotFoundException($"Inspection Visit with Id {request.Id} not found.");
            _mapper.Map(request, existingVisit);
            await _repository.UpdateAsync(existingVisit);
            await _repository.SaveChangesAsync();
            return true;

        }
    }
}
