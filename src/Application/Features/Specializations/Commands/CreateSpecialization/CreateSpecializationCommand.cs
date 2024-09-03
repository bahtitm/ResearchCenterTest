using Application.Features.Specializations.Dtos;

namespace Application.Features.Specializations.Commands.CreateSpecialization
{
    public class CreateSpecializationCommand : IRequest<SpecializationDto>
    {
        public string? Name { get; set; }
    }
}
