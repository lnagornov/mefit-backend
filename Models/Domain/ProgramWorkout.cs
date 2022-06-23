namespace MeFitCase_Assignment.Models.Domain;

public partial class ProgramWorkout
{
    public int Id { get; set; }
    public int ProgramId { get; set; }
    public int WorkoutId { get; set; }

    public virtual Program Program { get; set; } = null!;
    public virtual Workout Workout { get; set; } = null!;
}