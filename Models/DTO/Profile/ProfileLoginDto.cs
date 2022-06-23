namespace MeFitCase_Assignment.Models.DTOs;

public class ProfileLoginDto
{
    public int Id { get; set; }
    public string KeycloakId { get; set; }
    public int? GoalId { get; set; }
    public int? AddressId { get; set; }
    public int? FitnessAttributesId { get; set; }
}