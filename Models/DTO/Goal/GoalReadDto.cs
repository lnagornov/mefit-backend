using MeFitCase_Assignment.Models.DTO.Workout;

namespace MeFitCase_Assignment.Models.DTO.Goal;

public class GoalReadDto
{
    public int Id { get; set; }
    public string? EndDate { get; set; }
    public bool? IsAchieved { get; set; }
    public int? ProgramId { get; set; }
    public List<WorkoutDetailsReadDto>? Workouts { get; set; }
}