using ApplicationLayer.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityToInspect.Commands
{
    public class DeleteEntityToInspectCommandHandler : IRequestHandler<DeleteEntityCommand, bool>
    {
        private readonly IGenericRepository<Domain.Models.EntityToInspect> _repository;

        public DeleteEntityToInspectCommandHandler(IGenericRepository<Domain.Models.EntityToInspect> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteEntityCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
                throw new KeyNotFoundException($"Entity with Id {request.Id} not found.");

            await _repository.DeleteAsync(entity);

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}
