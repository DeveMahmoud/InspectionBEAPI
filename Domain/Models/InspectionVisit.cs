using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class InspectionVisit
    {

        public int Id { get; set; }
        public int EntityToInspectId { get; set; }
        public EntityToInspect? EntityToInspect { get; set; }
        public int InspectorId { get; set; }
        public Inspector? Inspector { get; set; }
        public DateTime ScheduledAt { get; set; }
        public VisitStatus Status { get; set; } = VisitStatus.Planned;
        public int? Score { get; set; }
        public string? Notes { get; set; }
        public ICollection<Violation>? Violations { get; set; }
    }
}
