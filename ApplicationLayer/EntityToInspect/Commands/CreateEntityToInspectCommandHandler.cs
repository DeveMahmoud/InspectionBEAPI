using ApplicationLayer.Interfaces;
using AutoMapper;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApplicationLayer.EntityToInspect.Commands
{
    public class CreateEntityToInspectCommandHandler : IRequestHandler<CreateEntityToInspectCommand, int>
    {
        private readonly IGenericRepository<Domain.Models.EntityToInspect> _repository;
        private readonly IMapper _mapper;

        public CreateEntityToInspectCommandHandler(IGenericRepository<Domain.Models.EntityToInspect> repository, IMapper mapper) 
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper;

        }

        public async Task<int> Handle(CreateEntityToInspectCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Models.EntityToInspect>(request);

            //var entity = new Domain.Models.EntityToInspect 
            //{
            //    Name = request.Name,
            //    Address = request.Address,
            //    Category = request.Category
            //};

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity.Id;
        }
    }
}
