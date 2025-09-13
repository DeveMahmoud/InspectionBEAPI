using ApplicationLayer.Mapping;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityToInspect.Queries
{
    public class GetAllEntitiesQuery: IRequest<IEnumerable<EntityDto>>
    {
    }
}
