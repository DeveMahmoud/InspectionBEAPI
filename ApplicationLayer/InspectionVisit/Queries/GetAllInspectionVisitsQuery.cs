using ApplicationLayer.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InspectionVisit.Queries
{
    public class GetAllInspectionVisitsQuery: IRequest<List<InspectionVisitQueryDto>>
    {
    }
}
