using AutoMapper;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Models.DTO.Address;
using MeFitCase_Assignment.Models.DTO.FitnessAttributes;
using MeFitCase_Assignment.Models.DTO.Profile;
using MeFitCase_Assignment.Models.DTOs;
using Profile = MeFitCase_Assignment.Models.Domain.Profile;

namespace MeFitCase_Assignment.Profiles;

public class ProfileProfile : AutoMapper.Profile
{
    public ProfileProfile()
    {
        CreateMap<Profile, ProfileReadDto>().ConvertUsing<ProfileReadDtoConverter>();
        CreateMap<Profile, ProfileLoginDto>().ConvertUsing<ProfileLoginDtoConverter>();
        CreateMap<ProfileCreateDto, Profile>();
        CreateMap<ProfileEditDto, Profile>();
        CreateMap<FitnessAttribute, FitnessAttributesReadDto>();
        CreateMap<FitnessAttributesEditDto, FitnessAttribute>();
        CreateMap<AddressEditDto, Address>();
    }
}

public class ProfileReadDtoConverter : ITypeConverter<Profile, ProfileReadDto>
{
    public ProfileReadDto Convert(Profile source, ProfileReadDto destination, ResolutionContext context)
    {
        destination = new ProfileReadDto
        {
            Id = source.Id,

            City = source.Address?.City,
            AddressLine1 = source.Address?.AddressLine1,
            AddressLine2 = source.Address?.AddressLine2,
            AddressLine3 = source.Address?.AddressLine3,
            Country = source.Address?.Country,
            PostalCode = source.Address?.PostalCode,
            
            Weight = source.FitnessAttributes?.Weight,
            Height = source.FitnessAttributes?.Height,
            MedicalConditions = source.FitnessAttributes?.MedicalConditions,
            Disabilities = source.FitnessAttributes?.Disabilities,

            GoalId = source.GoalId,
            GoalEndDate = $"{source.Goal?.EndDate:yyyy-MM-dd}",
            IsGoalAchieved = source.Goal?.IsAchieved,
            ProgramId = source.Goal?.ProgramId
        };
        
        return destination;
    }
}
public class ProfileLoginDtoConverter : ITypeConverter<Profile, ProfileLoginDto>
{
    public ProfileLoginDto Convert(Profile source, ProfileLoginDto destination, ResolutionContext context)
    {
        destination = new ProfileLoginDto
        {
            Id = source.Id,
            KeycloakId = source.KeycloakId,
            GoalId = source.GoalId,
            AddressId = source.AddressId,
            FitnessAttributesId = source.FitnessAttributesId
        };
        
        return destination;
    }
}