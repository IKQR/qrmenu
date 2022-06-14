using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]/{restaurantId}")]
    public class IngredientController : BaseApiController
    {
        private readonly IBaseDtoMapper<Ingredient, IngredientDto> _mapper;
        private readonly  IBaseBackMapper<Ingredient, IngredientDto> _backMapper;

        public IngredientController(DataDbContext dataContext,
            IBaseDtoMapper<Ingredient, IngredientDto> mapper, IBaseBackMapper<Ingredient, IngredientDto> backMapper)
            : base(dataContext)
        {
            this._mapper = mapper;
            _backMapper = backMapper;
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDto>> Get(
            [FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var ent = await _data.Ingredients
                .FirstOrDefaultAsync(x => x.Id == id && x.Restaurant.Id == restaurantId);
            
            if (ent is null) return NotFound();

            return _mapper.Map(ent);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientDto>>> Get(
            [FromRoute] int restaurantId)
        {
            var ent = await _data.Ingredients
                .Where(x => x.Restaurant.Id == restaurantId).ToArrayAsync();

            return Ok(_mapper.Map(ent));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IngredientDto ingredient,
            [FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ent = _backMapper.MapBack(ingredient);

            await _data.Ingredients.AddAsync(ent);
            await _data.SaveChangesAsync();
            return Ok();
        }
 
        [HttpPut]
        public async Task<IActionResult> Put(IngredientDto ingredient, 
            [FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var ent = await _data.Ingredients.FirstOrDefaultAsync(x => x.Id == ingredient.Id && 
                                                                 x.RestaurantId == restaurantId);
            if (ent is null) return NotFound();

            var entity = _backMapper.MapUpdate(ent, ingredient);
            _data.Ingredients.Update(entity);
            await _data.SaveChangesAsync();
            return Ok();
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var ingredient = await _data.Ingredients.FirstOrDefaultAsync(x => x.Id == id && 
                                                                  x.RestaurantId == restaurantId);
            if (ingredient is null) return NotFound();
            
            _data.Ingredients.Remove(ingredient);
            await _data.SaveChangesAsync();
            return Ok(ingredient);
        }
    }
}
