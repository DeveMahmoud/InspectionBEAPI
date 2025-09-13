using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Violation
    {
        public int Id { get; set; }
        public int InspectionVisitId { get; set; }
        public InspectionVisit? InspectionVisit { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Severity Severity { get; set; }
    }
}
