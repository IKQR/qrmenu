using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Controllers.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class RestaurantController : BaseApiController
    {
        private readonly IBaseDtoMapper<Restaurant, RestaurantDto> _mapper;
        private readonly IBaseBackMapper<Restaurant, RestaurantDto> _backMapper;

        public RestaurantController(DataDbContext dataContext,
            IBaseDtoMapper<Restaurant, RestaurantDto> mapper, IBaseBackMapper<Restaurant, RestaurantDto> backMapper)
            : base(dataContext)
        {
            this._mapper = mapper;
            _backMapper = backMapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> Get([FromRoute] int id)
        {
            var ent = await _data.Restaurants.FirstOrDefaultAsync(x => x.Id == id);

            if (ent is null) return NotFound();

            return Ok(_mapper.Map(ent));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> Get([FromQuery] string name = default)
        {
            var q = _data.Restaurants.AsQueryable();
            if (!string.IsNullOrEmpty(name))
            {
                q = q.Where(x => x.Name.Contains(name));
            }
            var ent = await q.ToArrayAsync();

            return Ok(_mapper.Map(ent));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RestaurantDto restaurant)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var ent = _backMapper.MapBack(restaurant);

            await _data.Restaurants.AddAsync(ent);
            await _data.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] RestaurantDto restaurant)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ent = await _data.Restaurants
                .FirstOrDefaultAsync(x => x.Id == restaurant.Id);
            if (ent is null) return NotFound();

            var entity = _backMapper.MapUpdate(ent, restaurant);
            _data.Restaurants.Update(entity);
            await _data.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var restaurant = await _data.Restaurants
                .FirstOrDefaultAsync(x => x.Id == id);
            if (restaurant is null) return NotFound();

            _data.Restaurants.Remove(restaurant);
            await _data.SaveChangesAsync();
            return Ok(restaurant);
        }
    }
}
