namespace MeFitCase_Assignment.Models.Domain;

public partial class FitnessAttribute
{
    public FitnessAttribute()
    {
        Profiles = new HashSet<Profile>();
    }

    public int Id { get; set; }
    public double? Weight { get; set; }
    public double? Height { get; set; }
    public string[]? MedicalConditions { get; set; }
    public string[]? Disabilities { get; set; }

    public virtual ICollection<Profile?> Profiles { get; set; }
}