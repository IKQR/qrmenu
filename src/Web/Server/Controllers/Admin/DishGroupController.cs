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
    public class DishesGroupController : BaseApiController
    {
        private readonly IBaseDtoMapper<DishesGroup, DishesGroupDto> _mapper;

        public DishesGroupController(DataDbContext dataContext,
            IBaseDtoMapper<DishesGroup, DishesGroupDto> mapper)
            : base(dataContext)
        {
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishesGroupDto>> Get(
            [FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var ent = await _data.DishesGroups
                .FirstAsync(x => x.Id == id && x.Restaurant.Id == restaurantId);

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
    }
}
