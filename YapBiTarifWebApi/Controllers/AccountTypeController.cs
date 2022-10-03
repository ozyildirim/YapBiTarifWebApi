using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YapBiTarifWebApi.Helpers;
using YapBiTarifWebApi.Models;

namespace YapBiTarifWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<AccountTypeModel>> Get()
        {
            return await _context.AccountTypes.ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(AccountTypeModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var accountType = await _context.AccountTypes.FindAsync(id);
            return accountType == null ? NotFound() : Ok(accountType);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateAccountTypeResponseModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateAccountTypeRequestModel accountType)
        {
            var entity = new AccountTypeModel { Name = accountType.Name };
            await _context.AccountTypes.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Create),
                new CreateAccountTypeResponseModel { Id = entity.Id, Name = entity.Name }
            );
        }

        [HttpPut("id")]
        [ProducesResponseType(typeof(CreateAccountTypeRequestModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, AccountTypeModel accountType)
        {
            if (id != accountType.Id)
                return BadRequest();

            _context.Entry(accountType).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(Update),
                new CreateAccountTypeResponseModel { Id = accountType.Id, Name = accountType.Name }
            );
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var accountTypeToDelete = await _context.AccountTypes.FindAsync(id);
            if (accountTypeToDelete == null)
                return NotFound();

            _context.AccountTypes.Remove(accountTypeToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
