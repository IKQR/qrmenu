using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Controllers.Admin
{
    [Route("api/admin/[controller]/{restaurantId}")]
    [ApiController]
    public class DishesGroupController : BaseApiController
    {
        private readonly IBaseDtoMapper<DishesGroup, DishesGroupDto> _mapper;
        private readonly IBaseBackMapper<DishesGroup, DishesGroupDto> _backMapper;

        public DishesGroupController(DataDbContext dataContext,
            IBaseDtoMapper<DishesGroup, DishesGroupDto> mapper, IBaseBackMapper<DishesGroup, DishesGroupDto> backMapper)
            : base(dataContext)
        {
            this._mapper = mapper;
            _backMapper = backMapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishesGroupDto>> Get(
            [FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var ent = await _data.DishesGroups
                .FirstOrDefaultAsync(x => x.Id == id && x.Restaurant.Id == restaurantId);
            
            if (ent is null) return NotFound();

            return _mapper.Map(ent);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DishesGroupDto>>> Get(
            [FromRoute] int restaurantId)
        {
            var ent = await _data.DishesGroups
                .Where(x => x.Restaurant.Id == restaurantId).ToArrayAsync();

            return Ok(_mapper.Map(ent));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DishesGroupDto dishesGroup,
            [FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ent = _backMapper.MapBack(dishesGroup);

            await _data.DishesGroups.AddAsync(ent);
            await _data.SaveChangesAsync();
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Put(DishesGroupDto dishesGroup, 
            [FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            dishesGroup.RestaurantId = restaurantId;
            
            var ent = await _data.DishesGroups.FirstOrDefaultAsync(x => x.Id == dishesGroup.Id && 
                                                                 x.RestaurantId == restaurantId);
            if (ent is null) return NotFound();

            var entity = _backMapper.MapUpdate(ent, dishesGroup);
            _data.DishesGroups.Update(entity);
            await _data.SaveChangesAsync();
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var dishesGroup = await _data.DishesGroups.FirstOrDefaultAsync(x => x.Id == id && 
                                                                  x.RestaurantId == restaurantId);
            if (dishesGroup is null) return NotFound();
            
            _data.DishesGroups.Remove(dishesGroup);
            await _data.SaveChangesAsync();
            return Ok(dishesGroup);
        }

    }
}
