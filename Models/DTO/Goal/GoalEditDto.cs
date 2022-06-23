namespace MeFitCase_Assignment.Models.DTO.Goal;

public class GoalEditDto
{
    public int Id { get; set; }
    public string EndDate { get; set; }
    public bool IsAchieved { get; set; }
    public int ProgramId { get; set; }
}