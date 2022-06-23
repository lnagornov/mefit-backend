namespace MeFitCase_Assignment.Models.DTO.Workout;

public class WorkoutDetailsReadDto
{
    public int Id { get; set; }
    public string? EndDate { get; set; }
    public bool? IsCompleted { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public int NumberOfExercises { get; set; } = 0;
}