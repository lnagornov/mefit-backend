namespace MeFitCase_Assignment.Models.Domain;

public partial class Exercise
{
    public Exercise()
    {
        Sets = new HashSet<Set>();
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? TargetMuscleGroup { get; set; }
    public string? ImageLink { get; set; }
    public string? VideoLink { get; set; }

    public virtual ICollection<Set> Sets { get; set; }
}