namespace MeFitCase_Assignment.Models.Domain;

public partial class Goal
{
    public Goal()
    {
        GoalWorkouts = new HashSet<GoalWorkout>();
        Profiles = new HashSet<Profile>();
    }

    public int Id { get; set; }
    public DateOnly? EndDate { get; set; }
    public bool? IsAchieved { get; set; }
    public int? ProgramId { get; set; }

    public virtual Program? Program { get; set; }
    public virtual ICollection<GoalWorkout> GoalWorkouts { get; set; }
    public virtual ICollection<Profile> Profiles { get; set; }
}