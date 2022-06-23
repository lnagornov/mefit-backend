namespace MeFitCase_Assignment.Models.Domain;

public partial class GoalWorkout
{
    public int Id { get; set; }
    public DateOnly? EndDate { get; set; }

    public bool? IsCompleted { get; set; }
    public int GoalId { get; set; }
    public int WorkoutId { get; set; }

    public virtual Goal? Goal { get; set; } = null!;
    public virtual Workout? Workout { get; set; } = null!;
}