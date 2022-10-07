using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YapBiTarifWebApi.Helpers;
using YapBiTarifWebApi.Models;

namespace YapBiTarifWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipeTypeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRecipeTypeRepository _recipeTypeRepository;

        public RecipeTypeController(DataContext context, IRecipeTypeRepository recipeTypeRepository)
        {
            _context = context;
            _recipeTypeRepository = recipeTypeRepository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RecipeTypeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IEnumerable<RecipeTypeModel> GetAll()
        {
            return _recipeTypeRepository.GetAll();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(RecipeTypeModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var recipeType = await _recipeTypeRepository.GetById(id);
            return recipeType == null ? NotFound() : Ok(recipeType);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateRecipeTypeResponseModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateRecipeTypeRequestModel recipeType)
        {
            var entity = new RecipeTypeModel { Name = recipeType.Name };
            await _recipeTypeRepository.Create(entity);

            return CreatedAtAction(nameof(GetById), entity);
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, RecipeTypeModel recipeType)
        {
            if (id != recipeType.Id)
                return BadRequest();

            var model = await _recipeTypeRepository.GetById(id);

            if (model == null)
                return NotFound();

            await _recipeTypeRepository.Update(id, recipeType);

            return CreatedAtAction(nameof(Update), recipeType);
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var recipeTypeToDelete = await _context.RecipeTypes.FindAsync(id);
            if (recipeTypeToDelete == null)
                return NotFound();

            _context.RecipeTypes.Remove(recipeTypeToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
