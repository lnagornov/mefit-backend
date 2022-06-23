namespace MeFitCase_Assignment.Models.Domain;

public partial class Set
{
    public int Id { get; set; }
    public int? ExerciseRepetitions { get; set; }
    public int ExerciseId { get; set; }
    public int WorkoutId { get; set; }
    public int ExerciseSets { get; set; }

    public virtual Exercise Exercise { get; set; } = null!;
    public virtual Workout Workout { get; set; } = null!;
}