﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityToInspect.Commands
{
    public class DeleteEntityCommand: IRequest<bool>
    {
        public int Id { get; set; }

    }
}
