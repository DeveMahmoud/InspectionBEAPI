using ApplicationLayer.Mapping;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityToInspect.Commands
{
    public class UpdateEntityToInspectCommand: IRequest<EntityDto>
    {
        public int Id { get; set; }       // Entity ID
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}
