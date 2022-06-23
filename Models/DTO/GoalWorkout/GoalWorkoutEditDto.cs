namespace MeFitCase_Assignment.Models.DTO.GoalWorkout;

public class GoalWorkoutEditDto
{
    public int? Id { get; set; }
    public string? EndDate { get; set; }
    public bool? IsCompleted { get; set; }
    public int GoalId { get; set; }
    public int WorkoutId { get; set; }
}