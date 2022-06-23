using Microsoft.AspNetCore.Mvc;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Repositories.Interfaces;
using AutoMapper;
using MeFitCase_Assignment.Models.DTO.Exercise;
using System.Net.Mime;

namespace MeFitCase_Assignment.Controllers
{

    [Route("[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseAsyncRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public ExercisesController(IExerciseAsyncRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        // GET: exercises/byworkout/5
        /// <summary>
        /// Get exercises by workout id
        /// </summary>
        /// <param name="id">Id of the workout to get exercises from</param>
        /// <returns>A list of exercise or Status code 404 Not Found (failure)</returns>
        [HttpGet("byworkout/{workoutId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<ExerciseReadDto>>> GetExerciseByWorkoutId(int workoutId)
        {
            List<Set> sets = (List<Set>)await _exerciseRepository.GetSetsByWorkoutId(workoutId);

            List<ExerciseReadDto> exerciseDtos = new List<ExerciseReadDto>();
            foreach (Set set in sets)
            {
                Exercise exercise = await _exerciseRepository.GetByIdAsync(set.ExerciseId.ToString());

                ExerciseReadDto dto = new ExerciseReadDto();
                dto.Name = exercise.Name;
                dto.Description = exercise.Description;
                dto.TargetMuscleGroup = exercise.TargetMuscleGroup;
                dto.ImageLink = exercise.ImageLink;
                dto.VideoLink = exercise.VideoLink;
                dto.ExerciseRepetitions = set.ExerciseRepetitions;
                dto.ExerciseSets = set.ExerciseSets;
                dto.ExerciseId = exercise.Id;
                dto.WorkoutId = workoutId;

                exerciseDtos.Add(dto);
            }
            
            return Ok(exerciseDtos);

        }
    }
}
