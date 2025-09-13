using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class InspectionVisitDto
    {
        //    public int Id { get; set; }
        //    public int EntityToInspectId { get; set; }
        //    public int InspectorId { get; set; }
        //    public DateTime ScheduledAt { get; set; }
        //    public VisitStatus Status { get; set; }
        //    public int? Score { get; set; }
        //    public string? Notes { get; set; }

        public int Id { get; set; }
        public string EntityToInspectName { get; set; } = string.Empty;
        public DateTime ScheduledAt { get; set; }
        public string Status { get; set; } = string.Empty;
        public int? Score { get; set; }
        public string? Notes { get; set; }

    }
}
