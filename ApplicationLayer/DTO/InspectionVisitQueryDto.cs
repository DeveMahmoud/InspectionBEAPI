using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.DTO
{
    public class InspectionVisitQueryDto
    {
        public int Id { get; set; }
        public int EntityToInspectId { get; set; }
        public string? EntityToInspectName { get; set; } // اسم الجهة المرتبطة
        public int InspectorId { get; set; }
        public string? InspectorName { get; set; }       // اسم المفتش
        public DateTime ScheduledAt { get; set; }
        public VisitStatus Status { get; set; }
        public int? Score { get; set; }
        public string? Notes { get; set; }
    }
}
