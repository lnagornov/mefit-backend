using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using MeFitCase_Assignment.Models.DTO.Program;
using System.Net.Mime;
using MeFitCase_Assignment.Repositories.Interfaces;

namespace MeFitCase_Assignment.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiConventionType(typeof(DefaultApiConventions))]
public class ProgramsController : ControllerBase
{
    private readonly IProgramAsyncRepository _repository;
    private readonly IProgramWorkoutAsyncRepository _programWorkoutRepository;
    private readonly IMapper _mapper;
    public ProgramsController(IProgramAsyncRepository repository, IProgramWorkoutAsyncRepository programWorkoutRepository, IMapper mapper)
    {
        _repository = repository;
        _programWorkoutRepository = programWorkoutRepository;
        _mapper = mapper;
    }

    // GET: api/Programs
    /// <summary>
    /// Retrieve all Programs from the Database
    /// The Dto includes the number of workouts a program has
    /// </summary>
    /// <returns>A list of ProgramReadDtos, containg the information about a program including the number of workouts</returns>4
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProgramReadDto>>> GetPrograms()
    {

        var programs = await _repository.GetAllAsync();
        var programReadDto = _mapper.Map<List<ProgramReadDto>>(programs);


        foreach (var dto in programReadDto)
        {
            var programWorkouts = await _programWorkoutRepository.GetProgramWorkoutsByProgramId(dto.Id);
            dto.NumberOfWorkouts = programWorkouts.Count();
        }

        return Ok(programReadDto);
    }

    // GET: api/Programs/5
    /// <summary>
    /// Retrieve a specific program from the database based on the id
    /// </summary>
    /// <param name="id">The Id of the program to retrieve</param>
    /// <returns>A ProgramReadDto containg the information about the Program</returns>
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProgramReadDto>> GetProgram(int id)
    {
        var program = await _repository.GetByIdAsync(id.ToString());

        if (program == null)
        {
            return NotFound();
        }
        var programReadDto = _mapper.Map<ProgramReadDto>(program);

        var programWorkouts = await _programWorkoutRepository.GetProgramWorkoutsByProgramId(programReadDto.Id);
        programReadDto.NumberOfWorkouts = programWorkouts.Count();

        return Ok(programReadDto);
    }

    // PUT: api/Programs/5
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <param name="programDto"></param>
    /// <returns></returns>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutProgram(int id, ProgramEditDto programDto)
    {
        if (id != programDto.Id)
        {
            return BadRequest();
        }

        if (!await _repository.ExistsWithIdAsync(id.ToString()))
        {
            return NotFound();
        }

        var program = _mapper.Map<Models.Domain.Program>(programDto);
        await _repository.UpdateAsync(program);

        return NoContent();
    }

    // POST: api/Programs
    /// <summary>
    /// Creates a new database entry for program based on the body given
    /// </summary>
    /// <param name="programDto">Data about a program to create in the database</param>
    /// <returns>The created program with a 200OK status code</returns>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost]
    public async Task<ActionResult<ProgramReadDto>> PostProgram(ProgramCreateDto programDto)
    {
        var program = _mapper.Map<Models.Domain.Program>(programDto);

        program = await _repository.AddAsync(program);

        return CreatedAtAction("GetProgram", new { id = program!.Id }, program);
    }

    // DELETE: api/Programs/5
    /// <summary>
    /// Delete a specific Program based on the given Id
    /// </summary>
    /// <param name="id">Id of the program to Delete</param>
    /// <returns>A 204 Status when the Program has been succsesfully deleted</returns>
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProgram(int id)
    {
        if (!await _repository.ExistsWithIdAsync(id.ToString()))
        {
            return NotFound();
        }

        await _repository.DeleteByIdAsync(id.ToString());

        return NoContent();
    }
}