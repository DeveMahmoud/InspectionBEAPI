using ApplicationLayer.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dashboard
{
    public class GetUpcomingVisitsQuery : IRequest<List<UpcomingVisitDto>>
    {
    }
}
