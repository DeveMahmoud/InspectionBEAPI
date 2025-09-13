using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Inspector.Queries
{
    public class GetAllInspectorsQueryHandler : IRequestHandler<GetAllInspectorsQuery, List<InspectorDTO>>
    {
        private readonly IGenericRepository<Domain.Models.Inspector> _inspectorRepository;
        private readonly IMapper _mapper;

        public GetAllInspectorsQueryHandler(
            IGenericRepository<Domain.Models.Inspector> inspectorRepository,
            IMapper mapper)
        {
            _inspectorRepository = inspectorRepository;
            _mapper = mapper;
        }
        public async Task<List<InspectorDTO>> Handle(GetAllInspectorsQuery request, CancellationToken cancellationToken)
        {
            var inspectors = await _inspectorRepository
                .GetQueryable()
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<InspectorDTO>>(inspectors);
        }
    }
}
