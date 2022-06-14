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
    public class MenuController : BaseApiController
    {
        private readonly IBaseDtoMapper<Menu, MenuDto> _mapper;
        private readonly IBaseBackMapper<Menu, MenuDto> _backMapper;

        public MenuController(DataDbContext dataContext,
            IBaseDtoMapper<Menu, MenuDto> mapper, IBaseBackMapper<Menu, MenuDto> backMapper)
            : base(dataContext)
        {
            this._mapper = mapper;
            _backMapper = backMapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MenuDto>> Get(
            [FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var ent = await _data.Menus
                .FirstOrDefaultAsync(x => x.Id == id && x.Restaurant.Id == restaurantId);
            
            if (ent is null) return NotFound();

            return _mapper.Map(ent);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuDto>>> Get(
            [FromRoute] int restaurantId)
        {
            var ent = await _data.Menus
                .Where(x => x.Restaurant.Id == restaurantId).ToArrayAsync();

            return Ok(_mapper.Map(ent));
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MenuDto menu,
            [FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            menu.RestaurantId = restaurantId;

            var restaurant = await _data.Restaurants.FirstOrDefaultAsync(x => x.Id == restaurantId);
            if (restaurant is null) return NotFound();

            var ent = _backMapper.MapBack(menu);

            await _data.Menus.AddAsync(ent);
            await _data.SaveChangesAsync();
            return Ok();
        }
 
        [HttpPut]
        public async Task<IActionResult> Put(MenuDto menu, 
            [FromRoute] int restaurantId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            menu.RestaurantId = restaurantId;
            
            var ent = await _data.Menus.FirstOrDefaultAsync(x => x.Id == menu.Id && 
                                                                 x.RestaurantId == restaurantId);
            if (ent is null) return NotFound();

            var entity = _backMapper.MapUpdate(ent, menu);
            _data.Menus.Update(entity);
            await _data.SaveChangesAsync();
            return Ok();
        }
 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var menu = await _data.Menus.FirstOrDefaultAsync(x => x.Id == id && 
                                                                        x.RestaurantId == restaurantId);
            if (menu is null) return NotFound();
            
            _data.Menus.Remove(menu);
            await _data.SaveChangesAsync();
            return Ok(menu);
        }
        
        
    }
}
