using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InspectionVisit.Commands
{
    public class UpdateInspectionVisitCommand: IRequest<bool>
    {
        public int Id { get; set; }               

        public int EntityToInspectId { get; set; }
        public int InspectorId { get; set; }
        public DateTime ScheduledAt { get; set; }
        public int? Score { get; set; }
        public string? Notes { get; set; }
        public VisitStatus Status { get; set; } 
    }
}
