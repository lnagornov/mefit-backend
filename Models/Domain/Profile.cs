namespace MeFitCase_Assignment.Models.Domain;

public class Profile
{
    public int Id { get; set; }
    public string KeycloakId { get; set; }
    public int? GoalId { get; set; }
    public int? AddressId { get; set; }
    public int? FitnessAttributesId { get; set; }

    public virtual Address? Address { get; set; }
    public virtual FitnessAttribute? FitnessAttributes { get; set; }
    public virtual Goal? Goal { get; set; }
}