using AutoMapper;
using Demo.Services.AccountAPI.DTOs;
using Demo.Services.AccountAPI.Interfaces;
using Demo.Services.AccountAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Services.AccountAPI.Controllers
{
    public class AccountAPIController : ControllerBase
    {
        private readonly IAccountService _context;
        private readonly IMapper _mapper;

        private readonly string _notFoundMsg = "Account was not found.";
        private readonly string _badRequestdMsg = "id is not valid.";

        public AccountAPIController(IAccountService context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{userId:Guid}", Name = "GetAccount")]
        [ProducesResponseType(typeof(AccountDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(AccountDTO), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(AccountDTO), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AccountDTO>> GetAccount(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var account = await _context.GetAccountByIdAsync(userId);

            if (account == null)
            {
                return NotFound(_notFoundMsg);
            }

            return Ok(_mapper.Map<AccountDTO>(account));
        }

        [HttpDelete("userId:Guid", Name = "DeleteAccount")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAccount(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return BadRequest(_badRequestdMsg);
            }

            var isSuccess = await _context.DeleteAccountAsync(userId);

            if (!isSuccess)
            {
                return NotFound(_notFoundMsg);
            }

            return NoContent();
        }

        [HttpPatch("/api/account")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchAccount(Guid id, [FromBody] JsonPatchDocument<AccountDTO> accountDTO)
        {
            if (id == Guid.Empty)
            {
                return BadRequest("Invalid Input: Account Id is null");
            }

            var productFromDb = await _context.GetAccountByIdAsync(id, false);

            if (productFromDb == null)
            {
                return NotFound(_notFoundMsg);
            }

            var productFromDbAsDTO = _mapper.Map<AccountDTO>(productFromDb);

            accountDTO.ApplyTo(productFromDbAsDTO, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _mapper.Map<Account>(productFromDbAsDTO);

            await _context.PatchAccountAsync(product);

            return NoContent();
        }
    }
}
