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
    public class GetAllEntitiesQueryHandler : IRequestHandler<GetAllEntitiesQuery, IEnumerable<EntityDto>>
    {
        private readonly IGenericRepository<Domain.Models.EntityToInspect> _repository;
        private readonly IMapper _mapper;

        public GetAllEntitiesQueryHandler(IGenericRepository<Domain.Models.EntityToInspect> repository,IMapper mapper)
        {                                                                                                                                                   
            _repository = repository;
            _mapper = mapper;

        }

        //public async Task<IEnumerable<EntityDto>> Handle(GetAllEntitiesQuery request, CancellationToken cancellationToken)
        //{
        //    var entities = await _repository.GetAllAsync();
        //    return _mapper.Map<IEnumerable<EntityDto>>(entities);
        //}

        async Task<IEnumerable<EntityDto>> IRequestHandler<GetAllEntitiesQuery, IEnumerable<EntityDto>>.Handle(GetAllEntitiesQuery request, CancellationToken cancellationToken)
        {
           var entities  =await _repository.ListAsync();
            return _mapper.Map<IEnumerable<EntityDto>>(entities);

        }
    }
}
