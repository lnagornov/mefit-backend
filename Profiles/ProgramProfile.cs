using AutoMapper;
using MeFitCase_Assignment.Models.DTO.Program;

namespace MeFitCase_Assignment.Profiles;

public class ProgramProfile : Profile
{
    public ProgramProfile()
    {
        CreateMap<Models.Domain.Program, ProgramReadDto>().ConvertUsing<ProgramReadDtoConverter>();
        CreateMap<ProgramEditDto, Models.Domain.Program>();
        CreateMap<ProgramCreateDto, Models.Domain.Program>();
    }
}

public class ProgramReadDtoConverter : ITypeConverter<Models.Domain.Program, ProgramReadDto>
{
    public ProgramReadDto Convert(Models.Domain.Program source, ProgramReadDto destination, ResolutionContext context)
    {
        destination = new ProgramReadDto
        {
            Id = source.Id,
            Name = source.Name,
            Category = source.Category,
            Description = source.Description,
            NumberOfWorkouts = 0,
        };

        return destination;
    }
}
