using System.Net.Mime;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Models.DTO.Goal;
using MeFitCase_Assignment.Models.DTO.GoalWorkout;
using MeFitCase_Assignment.Repositories.Interfaces;
using MeFitCase_Assignment.Models.DTO.Workout;

namespace MeFitCase_Assignment.Controllers;

[Route("[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiConventionType(typeof(DefaultApiConventions))]
public class GoalsController : ControllerBase
{
    private readonly IGoalAsyncRepository _goalRepository;
    private readonly IProfileAsyncRepository _profileRepository;
    private readonly IProgramWorkoutAsyncRepository _programWorkoutRepository;
    private readonly IGoalWorkoutAsyncRepository _goalWorkoutRepository;
    private readonly IProgramAsyncRepository _programRepository;
    private readonly IWorkoutGoalControllerAsyncRepository _workoutRepository;
    private readonly IMapper _mapper;

    public GoalsController(
        IGoalAsyncRepository goalRepository,
        IProfileAsyncRepository profileRepository,
        IProgramAsyncRepository programRepository,
        IProgramWorkoutAsyncRepository programWorkoutRepository,
        IGoalWorkoutAsyncRepository goalWorkoutRepository,
        IWorkoutGoalControllerAsyncRepository workoutRepository,
        IMapper mapper)
    {
        _goalRepository = goalRepository;
        _profileRepository = profileRepository;
        _programRepository = programRepository;
        _programWorkoutRepository = programWorkoutRepository;
        _goalWorkoutRepository = goalWorkoutRepository;
        _workoutRepository = workoutRepository;
        _mapper = mapper;
    }

    // GET: api/goals
    /// <summary>
    /// Get all goals
    /// </summary>
    /// <returns>List of all goals</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GoalReadDto>>> GetGoals()
    {
        var goals = await _goalRepository.GetAllAsync();
        var goalsReadDto = _mapper.Map<List<GoalReadDto>>(goals);

        return Ok(goalsReadDto);
    }

    // GET: api/goals/5
    /// <summary>
    /// Get one specific goal by goal id
    /// </summary>
    /// <param name="id">Id of the goal to get</param>
    /// <returns>One specific goal or Status code 404 Not Found (failure)</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GoalReadDto>> GetGoal(int id)
    {
        var goal = await _goalRepository.GetByIdAsync(id.ToString());
        if (goal is null)
        {
            return NotFound();
        }

        var goalReadDto = _mapper.Map<GoalReadDto>(goal);
        goalReadDto.Workouts = new List<WorkoutDetailsReadDto>();

        var goalWorkouts = await _goalWorkoutRepository.GetGoalWorkoutsByGoalIdAsync(goal.Id);
        if(goalWorkouts is null)
        {
            return NotFound();
        }

        foreach (var goalWorkout in goalWorkouts)
        {
            WorkoutDetailsReadDto workoutDetailsReadDto = new WorkoutDetailsReadDto();
            workoutDetailsReadDto.EndDate = $"{goalWorkout.EndDate:yyyy-MM-dd}";
            workoutDetailsReadDto.IsCompleted = goalWorkout.IsCompleted;

            var workout = await _workoutRepository.GetByIdAsync(goalWorkout.WorkoutId);
            workoutDetailsReadDto.Name = workout!.Name;
            workoutDetailsReadDto.Type = workout.Type;
            workoutDetailsReadDto.Id = workout.Id;

            var sets = await _workoutRepository.GetSetsByWorkoutId(goalWorkout.WorkoutId);
            workoutDetailsReadDto.NumberOfExercises += sets.Count();

            goalReadDto.Workouts.Add(workoutDetailsReadDto);
        }

        return Ok(goalReadDto);
    }

    // PUT: api/Goals/5
    /// <summary>
    /// Update a goal by goal id
    /// </summary>
    /// <param name="id">Id of the goal to update</param>
    /// <param name="goalEditDto">Goal Edit DTO model to update on</param>
    /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutGoal(int id, GoalEditDto goalEditDto)
    {
        if (id != goalEditDto.Id)
        {
            return BadRequest();
        }

        if (!await _goalRepository.ExistsWithIdAsync(id.ToString()))
        {
            return NotFound();
        }

        var goal = _mapper.Map<Goal>(goalEditDto);
        await _goalRepository.UpdateAsync(goal);

        return NoContent();
    }

    // POST: api/goals
    /// <summary>
    /// Add a new goal by completing next steps:
    /// 1. Create new goal in Goal table
    /// 2. Get all Workouts of the given Program and add them to the new Goal.
    /// 3. Update user Profile with a new Goal ID
    /// </summary>
    /// <param name="goalCreateDto">Goal Create DTO model to add new Goal</param>
    /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<GoalReadDto>> PostGoal(GoalCreateDto goalCreateDto)
    {
        // Check that the given Profile ID does exist
        var profile = await _profileRepository.GetByIdAsync(goalCreateDto.ProfileId.ToString());
        if (profile is null)
        {
            return NotFound($"No such profile with this profileId = {goalCreateDto.ProfileId}");
        }
        // Check that the given Program ID does exist
        if (!await _programRepository.ExistsWithIdAsync(goalCreateDto.ProgramId.ToString()))
        {
            return NotFound($"No such program with this programId = {goalCreateDto.ProgramId}");
        }
        
        var goal = _mapper.Map<Goal>(goalCreateDto);
        goal = await _goalRepository.AddAsync(goal);

        // Get all workouts of the given program by program Id
        var programWorkouts = await _programWorkoutRepository
                .GetProgramWorkoutsByProgramId(goalCreateDto.ProgramId);
        
        // Assign workouts of the certain program to a new user goal
        var goalWorkouts = programWorkouts.Select(programWorkout => new GoalWorkout
            {
                WorkoutId = programWorkout!.WorkoutId,
                GoalId = goal!.Id,
                EndDate = goal.EndDate,
                IsCompleted = false
            })
            .ToList();

        await _goalWorkoutRepository.AddGoalWorkoutsAsync(goalWorkouts);
        await _profileRepository.UpdateProfileWithGoalIdAsync(profile, goal!.Id);

        return CreatedAtAction(
            nameof(GetGoal),
            new {id = goal.Id},
            _mapper.Map<GoalReadDto>(goal)
            );
    }

    // DELETE: api/goals/5
    /// <summary>
    /// Delete a goal by goal id
    /// </summary>
    /// <param name="id">Id of the goal to delete</param>
    /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGoal(int id)
    {
        if (!await _goalRepository.ExistsWithIdAsync(id.ToString()))
        {
            return NotFound();
        }

        await _goalRepository.DeleteByIdAsync(id.ToString());

        return NoContent();
    }
    
    // PUT: api/Goals/5/Workout/1
    /// <summary>
    /// Update a goal workout by goal id and workout id
    /// </summary>
    /// <param name="goalId">Id of the goal to update</param>
    /// <param name="workoutId">Id of the workout to update</param>
    /// <param name="goalWorkoutEditDto">GoalWorkout Edit DTO model to update on</param>
    /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
    [HttpPut("{goalId:int}/workouts/{workoutId:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutGoalWorkout(int goalId, int workoutId, [FromBody] GoalWorkoutEditDto goalWorkoutEditDto)
    {
        if (goalId != goalWorkoutEditDto.GoalId || workoutId != goalWorkoutEditDto.WorkoutId)
        {
            return BadRequest();
        }
        
        var goalWorkout = await _goalWorkoutRepository.GetGoalWorkoutByGoalIdAndWorkoutIdAsync(goalId, workoutId);

        if (goalWorkout is null)
        {
            return NotFound();
        }
        
        goalWorkout.EndDate = DateOnly.Parse(goalWorkoutEditDto.EndDate!);
        goalWorkout.IsCompleted = goalWorkoutEditDto.IsCompleted;
        goalWorkout.GoalId = goalWorkoutEditDto.GoalId;
        goalWorkout.WorkoutId = goalWorkoutEditDto.WorkoutId;
        
        await _goalWorkoutRepository.UpdateAsync(goalWorkout);

        return NoContent();
    }
}