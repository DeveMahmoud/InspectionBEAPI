using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.EntityToInspect.Commands
{
    public class CreateEntityToInspectCommandValidator: AbstractValidator<CreateEntityToInspectCommand>
    {
        public CreateEntityToInspectCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(100);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required");
        }
    }
}
