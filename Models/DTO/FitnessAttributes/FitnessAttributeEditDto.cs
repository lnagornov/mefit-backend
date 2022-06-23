namespace MeFitCase_Assignment.Models.DTO.FitnessAttributes;

public class FitnessAttributesEditDto
{
    public int Id { get; set; }
    public double? Weight { get; set; }
    public double? Height { get; set; }
    public string[]? MedicalConditions { get; set; }
    public string[]? Disabilities { get; set; }
}