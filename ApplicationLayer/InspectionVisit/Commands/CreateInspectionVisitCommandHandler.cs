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
    public class CreateInspectionVisitCommandHandler: IRequestHandler<CreateInspectionVisitCommand, int>
    {
        private readonly IGenericRepository<Domain.Models.InspectionVisit> _repository;
        private readonly IMapper _mapper;

        public CreateInspectionVisitCommandHandler(
            IGenericRepository<Domain.Models.InspectionVisit> repository,
            IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateInspectionVisitCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Models.InspectionVisit>(request);

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }
    }

}
