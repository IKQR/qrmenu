using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Controllers.Admin
{
    [Route("api/[controller]/{restaurantId}")]
    [ApiController]
    public class DishController : BaseApiController
    {
        private readonly IBaseDtoMapper<Dish, DishDto> _mapper;

        public DishController(
            DataDbContext dataContext,
            IBaseDtoMapper<Dish,DishDto> mapper) 
            : base(dataContext)
        {
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishDto>> Get(
            [FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var ent = await _data.Dishes
                .FirstAsync(x => x.Id == id && x.Restaurant.Id == restaurantId);

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

    }
}
