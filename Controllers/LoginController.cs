using Microsoft.AspNetCore.Mvc;
using MeFitCase_Assignment.Models.DTOs;
using AutoMapper;
using MeFitCase_Assignment.Repositories.Interfaces;

namespace MeFitCase_Assignment.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly ILoginAsyncRepository _profileRepository;
    private readonly IMapper _mapper;

    public LoginController(ILoginAsyncRepository profileRepository, IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }
        
    // GET: api/login/5
    /// <summary>
    /// Gets the profile of the user based on keycloak id.
    /// If no profile exists, a new one is created.
    /// </summary>
    /// <param name="id">User id from Keycloak</param>
    /// <returns>A profile Dto object</returns>
    /// <response code="200">Successfully returns profile dto object</response>
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("{userId}")]
    public async Task<ActionResult<ProfileLoginDto>> Login(string userId)
    {
        var profile = await _profileRepository.LoginAsync(userId);
        var profileReadDto = _mapper.Map<ProfileLoginDto>(profile);

        return Ok(profileReadDto);
    }
}