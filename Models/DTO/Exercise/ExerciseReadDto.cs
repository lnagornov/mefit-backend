namespace MeFitCase_Assignment.Models.DTO.Exercise
{
    public class ExerciseReadDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? TargetMuscleGroup { get; set; }
        public string? ImageLink { get; set; }
        public string? VideoLink { get; set; }
        public int? ExerciseRepetitions { get; set; }
        public int? ExerciseSets { get; set; }
        public int? ExerciseId { get; set; }
        public int? WorkoutId { get; set; }
    }
}
