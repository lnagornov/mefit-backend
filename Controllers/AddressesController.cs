using Microsoft.AspNetCore.Mvc;
using MeFitCase_Assignment.Models.Domain;
using System.Net.Mime;
using MeFitCase_Assignment.Repositories.Interfaces;
using AutoMapper;
using MeFitCase_Assignment.Models.DTO.Address;

namespace MeFitCase_Assignment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AddressesController : ControllerBase
    {
        private readonly IAddressAsyncRepository _addressRepository;
        private readonly IMapper _mapper;

        public AddressesController(IAddressAsyncRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        // PUT: /addressess/1
        /// <summary>
        /// Update fitness-attribute by address id
        /// </summary>
        /// <param name="id">Id of the address to update address</param>
        /// <param name="fitnessAttributesEditDto">address Edit DTO model to update on</param>
        /// <returns>Status code 204 No content (success) or Status code 404 Not found (failure)</returns>
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAddress(int id, AddressEditDto addressEditDto)
        {
            if (id != addressEditDto.Id)
            {
                return BadRequest();
            }

            if (!await _addressRepository.ExistsWithIdAsync(id.ToString()))
            {
                return NotFound("Address with the given id not found.");
            }

            var address = _mapper.Map<Address>(addressEditDto);
            await _addressRepository.UpdateAsync(address);

            return NoContent();
        }
    }
}
