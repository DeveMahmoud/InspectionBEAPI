using ApplicationLayer.DTO;
using ApplicationLayer.Inspector.Commands;
using ApplicationLayer.Interfaces;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.InspectionVisit.Commands
{
    public class CreateInspectorCommandHandler : IRequestHandler<CreateInspectorCommand, string>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<Domain.Models.Inspector> _inspectorRepository;
        public CreateInspectorCommandHandler(
            UserManager<ApplicationUser> userManager,
            IGenericRepository<Domain.Models.Inspector> inspectorRepository)
        {
            _userManager = userManager;
            _inspectorRepository = inspectorRepository;
        }

        public async Task<string> Handle(CreateInspectorCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Inspector;

            var user = new ApplicationUser
            {
                UserName = dto.Email,
                Email = dto.Email,
                PhoneNumber = dto.Phone
            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (!result.Succeeded)
                throw new Exception("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));

            await _userManager.AddToRoleAsync(user, "Inspector");

            var inspector = new Domain.Models.Inspector
            {
                UserId = user.Id,
                FullName = dto.FullName,
                Email = dto.Email,
                Phone = dto.Phone,
                Role = Enum.Parse<InspectorRole>(dto.Role, true)
            };

            await _inspectorRepository.AddAsync(inspector);
            await _inspectorRepository.SaveChangesAsync();

            return user.Id;
        }
    }
}
    
