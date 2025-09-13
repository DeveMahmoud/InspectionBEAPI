using ApplicationLayer.Mapping;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityToInspect.Queries
{
    public class GetEntityToInspectByIdQuery: IRequest<EntityDto>
    {
        public int Id { get; set; }
    }
}
