using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Controllers.Admin
{
    [Route("api/[controller]/{restaurantId}")]
    [ApiController]
    public class DishController : BaseApiController
    {
        private readonly IBaseDtoMapper<Dish, DishDto> _mapper;
        private readonly IBaseBackMapper<Dish, DishDto> _backMapper;

        public DishController(
            DataDbContext dataContext,
            IBaseDtoMapper<Dish,DishDto> mapper, IBaseBackMapper<Dish, DishDto> backMapper) 
            : base(dataContext)
        {
            this._mapper = mapper;
            _backMapper = backMapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishDto>> Get(
            [FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var ent = await _data.Dishes
                .FirstOrDefaultAsync(x => x.Id == id && x.Restaurant.Id == restaurantId);
            
            if (ent is null) return NotFound();

            return _mapper.Map(ent);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishDto>>> Get(
            [FromRoute] int restaurantId)
        {
            var ent = await _data.Dishes
                .Where(x => x.Restaurant.Id == restaurantId).ToArrayAsync();

            return Ok(_mapper.Map(ent));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DishDto dish,
            [FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            dish.RestaurantId = restaurantId;

            var ent = _backMapper.MapBack(dish);

            await _data.Dishes.AddAsync(ent);
            await _data.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(DishDto dish, 
            [FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            dish.RestaurantId = restaurantId;
            
            var ent = await _data.Dishes.FirstOrDefaultAsync(x => x.Id == dish.Id && 
                                                                        x.RestaurantId == restaurantId);
            if (ent is null) return NotFound();

            var entity = _backMapper.MapUpdate(ent, dish);
            _data.Dishes.Update(entity);
            await _data.SaveChangesAsync();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var dish = await _data.Dishes.FirstOrDefaultAsync(x => x.Id == id && 
                x.RestaurantId == restaurantId);
            if (dish is null) return NotFound();
            
            _data.Dishes.Remove(dish);
            await _data.SaveChangesAsync();
            return Ok(dish);
        }

    }
}
