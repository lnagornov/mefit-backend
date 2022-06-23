namespace MeFitCase_Assignment.Models.Domain;

public partial class Workout
{
    public Workout()
    {
        GoalWorkouts = new HashSet<GoalWorkout>();
        ProgramWorkouts = new HashSet<ProgramWorkout>();
        Sets = new HashSet<Set>();
    }

    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
        

    public virtual ICollection<GoalWorkout> GoalWorkouts { get; set; }
    public virtual ICollection<ProgramWorkout> ProgramWorkouts { get; set; }
    public virtual ICollection<Set> Sets { get; set; }
}