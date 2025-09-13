using ApplicationLayer.Interfaces;
using ApplicationLayer.Mapping;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityToInspect.Queries
{
    public class GetEntityByIdQueryHandler : IRequestHandler<GetEntityToInspectByIdQuery, EntityDto>
    {
        private readonly IGenericRepository<Domain.Models.EntityToInspect> _repository;
        private readonly IMapper _mapper;

        public GetEntityByIdQueryHandler(IGenericRepository<Domain.Models.EntityToInspect> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EntityDto> Handle(GetEntityToInspectByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with Id {request.Id} not found.");

            return _mapper.Map<EntityDto>(entity);
        }
    }
}
