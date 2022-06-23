using System.Net.Mime;
using AutoMapper;
using MeFitCase_Assignment.Models.DTO.Profile;
using MeFitCase_Assignment.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Profile = MeFitCase_Assignment.Models.Domain.Profile;

namespace MeFitCase_Assignment.Controllers;

[ApiController]
[Route("[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Consumes(MediaTypeNames.Application.Json)]
[ApiConventionType(typeof(DefaultApiConventions))]
public class ProfilesController : ControllerBase
{
    private readonly IProfileAsyncRepository _profileRepository;
    private readonly IMapper _mapper;

    public ProfilesController(
        IProfileAsyncRepository profileRepository,
        IMapper mapper)
    {
        _profileRepository = profileRepository;
        _mapper = mapper;
    }

    // GET: /profiles/1
    /// <summary>
    /// Get one specific profile by user id
    /// </summary>
    /// <param name="userId">Id of the user to get</param>
    /// <returns>One specific profile or Status code 404 Not Found (failure)</returns>
    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProfileReadDto>> GetProfile(string userId)
    {
        var profile = await _profileRepository.GetByUserIdAsync(userId);
        if (profile is null)
        {
            return NotFound();
        }

        var profileReadDto = _mapper.Map<ProfileReadDto>(profile);

        return Ok(profileReadDto);
    }

    // GET: /profiles
    /// <summary>
    /// Get all profiles
    /// </summary>
    /// <returns>List of all profiles</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<ProfileReadDto>>> GetProfiles()
    {
        var profiles = await _profileRepository.GetAllAsync();
        var profilesReadDto = _mapper.Map<List<ProfileReadDto>>(profiles);

        return Ok(profilesReadDto);
    }

    // PUT: /profiles/1
    /// <summary>
    /// Update a profile by profile id
    /// </summary>
    /// <param name="userId">Id of the user to update profile</param>
    /// <param name="profileEditDto">Profile Edit DTO model to update on</param>
    /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
    [HttpPut("{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PutProfile(string userId, ProfileEditDto profileEditDto)
    {
        if (userId != profileEditDto.KeycloakId)
        {
            return BadRequest();
        }

        // TODO: Replace with ExistsWIthUserIdAsync
        if (!await _profileRepository.ExistsWithIdAsync(userId))
        {
            return NotFound();
        }

        var profile = _mapper.Map<Profile>(profileEditDto);
        await _profileRepository.UpdateAsync(profile);

        return NoContent();
    }

    // POST: /profiles
    /// <summary>
    /// Add a new profile
    /// </summary>
    /// <param name="profileCreateDto">Profile Create DTO model to add new Profile</param>
    /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<ProfileReadDto>> PostProfile(ProfileCreateDto profileCreateDto)
    {
        var profile = _mapper.Map<Profile>(profileCreateDto);
        profile = await _profileRepository.AddAsync(profile);

        return CreatedAtAction(
            nameof(GetProfile),
            new {userId = profile?.KeycloakId},
            profile);
    }

    // DELETE: /profiles/1
    /// <summary>
    /// Delete a profile by keycloak id as user id
    /// </summary>
    /// <param name="userId">Id of the user to delete profile</param>
    /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
    [HttpDelete("{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteProfile(string userId)
    {
        // TODO: Replace with ExistsWIthUserIdAsync
        if (!await _profileRepository.ExistsWithIdAsync(userId))
        {
            return NotFound();
        }

        // TODO: Replace with DeleteByUserId
        await _profileRepository.DeleteByIdAsync(userId);

        return NoContent();
    }
    }