using Domain.Enums;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InspectionVisit.Commands
{
    public class CreateInspectionVisitCommand: IRequest<int>
    {
        public int EntityToInspectId { get; set; }
        public int InspectorId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public int? Score { get; set; }
        public string? Notes { get; set; }
        public VisitStatus Status { get; set; } = VisitStatus.Planned;
    }

    public class ViolationDto
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Severity { get; set; } // 0 = Low, 1 = Medium, 2 = High
    }
}
