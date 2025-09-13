using ApplicationLayer.Interfaces;
using ApplicationLayer.Mapping;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityToInspect.Commands
{
    public class UpdateEntityToInspectCommandHandler : IRequestHandler<UpdateEntityToInspectCommand, EntityDto>

    {

        private readonly IGenericRepository<Domain.Models.EntityToInspect> _repository;
        private readonly IMapper _mapper;
        public UpdateEntityToInspectCommandHandler(IGenericRepository<Domain.Models.EntityToInspect> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<EntityDto> Handle(UpdateEntityToInspectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new KeyNotFoundException($"Entity with Id {request.Id} not found.");

            entity.Name = request.Name;
            entity.Address = request.Address;
            entity.Category = request.Category;

            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<EntityDto>(entity);
        }
    }
}
