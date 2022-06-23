using System.Net.Mime;
using AutoMapper;
using MeFitCase_Assignment.Models.Domain;
using MeFitCase_Assignment.Models.DTO.FitnessAttributes;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MeFitCase_Assignment.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiConventionType(typeof(DefaultApiConventions))]
public class FitnessAttributesController : ControllerBase
{
    private readonly IFitnessAttributesAsyncRepository _fitnessAttributesRepository;
    private readonly IMapper _mapper;
    
    public FitnessAttributesController(
        IFitnessAttributesAsyncRepository fitnessAttributesRepository,
        IMapper mapper)
    {
        _fitnessAttributesRepository = fitnessAttributesRepository;
        _mapper = mapper;
    }
    
    // GET: /fitness-attributes/1
    /// <summary>
    /// Get one specific fitness-attribute by fitness-attribute id
    /// </summary>
    /// <param name="id">Id of the fitness-attribute to get</param>
    /// <returns>One specific fitness-attribute or Status code 404 Not Found (failure)</returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<FitnessAttributesReadDto>> GetFitnessAttributes(int id)
    {
        var fitnessAttribute = await _fitnessAttributesRepository.GetByIdAsync(id.ToString());
        if (fitnessAttribute is null)
        {
            return NotFound();
        }
        
        var fitnessAttributeReadDto = _mapper.Map<FitnessAttributesReadDto>(fitnessAttribute);

        return Ok(fitnessAttributeReadDto);
    }
    
    
    // PUT: /fitness-attributes/1
    /// <summary>
    /// Update fitness-attribute by fitness-attribute id
    /// </summary>
    /// <param name="id">Id of the fitness-attribute to update fitness attributes</param>
    /// <param name="fitnessAttributesEditDto">Fitness Attributes Edit DTO model to update on</param>
    /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutFitnessAttributes(int id, FitnessAttributesEditDto fitnessAttributesEditDto)
    {
        if (id != fitnessAttributesEditDto.Id)
        {
            return BadRequest();
        }

        if (!await _fitnessAttributesRepository.ExistsWithIdAsync(id.ToString()))
        {
            return NotFound("Fitness attributes with the given id not found.");
        }

        var fitnessAttribute = _mapper.Map<FitnessAttribute>(fitnessAttributesEditDto);
        await _fitnessAttributesRepository.UpdateAsync(fitnessAttribute);

        return NoContent();
    }
}