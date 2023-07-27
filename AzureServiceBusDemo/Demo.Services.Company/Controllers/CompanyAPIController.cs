using AutoMapper;
using Demo.Services.CompanyAPI.DTOs;
using Demo.Services.CompanyAPI.Interfaces;
using Demo.Services.CompanyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Services.CompanyAPI.Controllers
{
    /// <summary>
    /// Class CompanyAPIControl contains CRUD endpoints for Company
    /// </summary>
    [ApiController]
    [Route("api/company")]
    public class CompanyAPIController : ControllerBase
    {
        private readonly ICompanyService _context;
        private readonly IMapper _mapper;

        private readonly string _notFoundMsg = "Company was not found.";
        private readonly string _badRequestdMsg = "Company Id is not valid.";

        public CompanyAPIController(ICompanyService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all Companies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(CompanyDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CompanyDTO>>> GetCompanies()
        {
           var companies = await _context.GetCompaniesAsync();

            return Ok(_mapper.Map<IEnumerable<CompanyDTO>>(companies));
        }

        /// <summary>
        /// Gets a single Company by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:Guid}", Name = "GetCompany")]
        [ProducesResponseType(typeof(CompanyDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CompanyDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CompanyDTO), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompanyDTO>> GetCompany(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var company = await _context.GetCompanyByIdAsync(id);

            if (company == null)
            {
                return NotFound(_notFoundMsg);
            }

            return Ok(_mapper.Map<CompanyDTO>(company));
        }

        /// <summary>
        /// Adds new Company
        /// </summary>
        /// <param name="companyDTO"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CompanyDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CompanyDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(CompanyDTO), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CompanyDTO>> CreateCompany([FromBody] CompanyDTO companyDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (companyDTO == null)
            {
                return BadRequest(companyDTO);
            }

            if (companyDTO.Id != Guid.Empty)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Can not add company with an id");
            }

            Company company = _mapper.Map<Company>(companyDTO);
            company = await _context.AddCompnayAsync(company);

            /* NOTE TO KEITH:
             *      To get the actual location when returning created at route, we need to pass the id of the entity that was added to db.
             *      Otherwise it will not point to the right URL.
             *      
             *      ex. In moris microserve I see that we're returning the id of the DTO which does not have the db generated identity.
            */

            return CreatedAtRoute("GetCompany", new { id = company.Id }, companyDTO);
        }

        /// <summary>
        /// Deletes a Company
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:Guid}", Name = "DeleteCompany")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCompany(Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var company = await _context.DeleteCompanyAsync(id);

            if (company == null)
            {
                return NotFound(_notFoundMsg);
            }

            return NoContent();
        }

       [HttpPut]
       [ProducesResponseType(StatusCodes.Status204NoContent)]
       [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateCompany(Guid id, [FromBody] CompanyDTO companyDTO)
        {
            if (companyDTO == null || id != companyDTO.Id)
            {
                return BadRequest("Invalid Input: Company is null OR id does not match the companyId");
            }

            Company company = _mapper.Map<Company>(companyDTO);

            await _context.UpdateCompanyAsyc(company);

            return NoContent();
        }

        // PATCH
    }
}
