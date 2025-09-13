using ApplicationLayer.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Inspector.Commands
{
    public class CreateInspectorCommand: IRequest<string>
    {
        public CreateInspectorDTO Inspector { get; set; }

        public CreateInspectorCommand(CreateInspectorDTO inspector)
        {
            Inspector = inspector;
        }

    }
}
