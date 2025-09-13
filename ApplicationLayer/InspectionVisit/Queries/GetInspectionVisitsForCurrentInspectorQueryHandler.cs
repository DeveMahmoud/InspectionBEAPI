using ApplicationLayer.DTO;
using ApplicationLayer.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InspectionVisit.Queries
{
    public class GetInspectionVisitsForCurrentInspectorQueryHandler
        : IRequestHandler<GetInspectionVisitsForCurrentInspectorQuery, List<InspectionVisitDto>>
    {

        private readonly IGenericRepository<Domain.Models.InspectionVisit> _visitRepository;
        private readonly IGenericRepository<Domain.Models.Inspector> _inspectorRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public GetInspectionVisitsForCurrentInspectorQueryHandler(
            IGenericRepository<Domain.Models.InspectionVisit> visitRepository,
            IGenericRepository<Domain.Models.Inspector> inspectorRepository,
            IHttpContextAccessor httpContextAccessor,
            IMapper mapper)
        {
            _visitRepository = visitRepository;
            _inspectorRepository = inspectorRepository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<List<InspectionVisitDto>> Handle(GetInspectionVisitsForCurrentInspectorQuery request, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(userId))
                throw new UnauthorizedAccessException("User is not logged in.");

            var inspector = await _inspectorRepository
                .GetQueryable()
                .FirstOrDefaultAsync(i => i.UserId == userId, cancellationToken);

            if (inspector == null)
                throw new KeyNotFoundException("Inspector not found for this user.");

            var visits = await _visitRepository
                .GetQueryable()
                .Include(v => v.EntityToInspect)
                .Where(v => v.InspectorId == inspector.Id)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<InspectionVisitDto>>(visits);
        }
    }
    
}
