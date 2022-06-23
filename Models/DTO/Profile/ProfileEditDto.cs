using MeFitCase_Assignment.Models.Domain;

namespace MeFitCase_Assignment.Models.DTO.Profile;

public class ProfileEditDto
{
    public int Id { get; set; }
    public string? KeycloakId { get; set; }
    public int? GoalId { get; set; }
    public int? AddressId { get; set; }
    public int? FitnessAttributesId { get; set; }
}