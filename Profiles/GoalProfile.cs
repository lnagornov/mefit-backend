using AutoMapper;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Models.DTO.Goal;
using MeFitCase_Assignment.Models.DTO.GoalWorkout;


namespace MeFitCase_Assignment.Profiles;

public class GoalProfile : AutoMapper.Profile
{
    public GoalProfile()
    {
        CreateMap<Goal, GoalReadDto>().ConvertUsing<GoalReadDtoConverter>();
        CreateMap<GoalEditDto, Goal>().ConvertUsing<GoalEditDtoConverter>();
        CreateMap<GoalCreateDto, Goal>().ConvertUsing<GoalCreateDtoConverter>();
    }
}

public class GoalReadDtoConverter : ITypeConverter<Goal, GoalReadDto>
{
    public GoalReadDto Convert(Goal source, GoalReadDto destination, ResolutionContext context)
    {
        destination = new GoalReadDto
        {
            Id = source.Id,
            EndDate = $"{source.EndDate:yyyy-MM-dd}",
            IsAchieved = source.IsAchieved,
            ProgramId = source.ProgramId,
        };

        return destination;
    }
}

public class GoalCreateDtoConverter : ITypeConverter<GoalCreateDto, Goal>
{
    public Goal Convert(GoalCreateDto source, Goal destination, ResolutionContext context)
    {
        destination = new Goal
        {
            EndDate = DateOnly.Parse(source.EndDate),
            ProgramId = source.ProgramId
        };
        
        return destination;
    }
}

public class GoalEditDtoConverter : ITypeConverter<GoalEditDto, Goal>
{
    public Goal Convert(GoalEditDto source, Goal destination, ResolutionContext context)
    {
        destination = new Goal
        {
            Id = source.Id,
            EndDate = DateOnly.Parse(source.EndDate),
            IsAchieved = source.IsAchieved,
            ProgramId = source.ProgramId,
        };
        
        return destination;
    }
}