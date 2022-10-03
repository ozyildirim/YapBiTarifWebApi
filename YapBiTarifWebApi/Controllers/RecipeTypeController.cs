using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public RecipeTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RecipeTypeModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<RecipeTypeModel>> Get()
        {
            return await _context.RecipeTypes.ToListAsync();
        }

        [HttpGet("id")]
        [ProducesResponseType(typeof(RecipeTypeModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var recipeType = await _context.RecipeTypes.FindAsync(id);
            return recipeType == null ? NotFound() : Ok(recipeType);
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateRecipeTypeResponseModel), StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(CreateRecipeTypeRequestModel recipeType)
        {
            var entity = new RecipeTypeModel { Name = recipeType.Name };
            await _context.RecipeTypes.AddAsync(entity);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), entity);
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, RecipeTypeModel recipeType)
        {
            if (id != recipeType.Id)
                return BadRequest();

            var model = await _context.RecipeTypes.FindAsync(id);

            if (model == null)
                return NotFound();

            _context.Entry(recipeType).State = EntityState.Modified;
            _context.Update(recipeType);
            await _context.SaveChangesAsync();

            return NoContent();
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
