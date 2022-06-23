namespace MeFitCase_Assignment.Models.DTO.Program;

public class ProgramReadDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public int NumberOfWorkouts { get; set; } = 0;
}