using ApplicationLayer.DTO;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Violation.Commands
{
    public class CreateViolationCommand : IRequest<int>
    {
        public int InspectionVisitId { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Severity Severity { get; set; }
    }

}
