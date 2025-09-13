using ApplicationLayer.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Inspector.Queries
{
    public class GetAllInspectorsQuery : IRequest<List<InspectorDTO>>
    {
    }
}
