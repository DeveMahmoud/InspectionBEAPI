using ApplicationLayer.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Violation.Queries
{
    public class GetViolationByIdQuery : IRequest<ViolationDto>
    {
        public int Id { get; set; }

    }
}
