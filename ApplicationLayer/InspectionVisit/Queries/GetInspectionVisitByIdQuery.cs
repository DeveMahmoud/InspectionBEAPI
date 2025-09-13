using ApplicationLayer.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InspectionVisit.Queries
{
    public class GetInspectionVisitByIdQuery: IRequest<InspectionVisitQueryDto>
    {
        public int Id { get; set; }

        public GetInspectionVisitByIdQuery(int id)
        {
            Id = id;
        }
    }

}
