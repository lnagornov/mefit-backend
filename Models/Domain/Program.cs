namespace MeFitCase_Assignment.Models.Domain;

public class Program
{
    public Program()
    {
        Goals = new HashSet<Goal>();
        ProgramWorkouts = new HashSet<ProgramWorkout>();
    }

    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Category { get; set; } = null!;
    public string Description { get; set; }
    public virtual ICollection<Goal> Goals { get; set; }
    public virtual ICollection<ProgramWorkout> ProgramWorkouts { get; set; }
}