using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class RestaurantController : BaseApiController
    {
        private readonly IBaseDtoMapper<Restaurant, RestaurantDto> _mapper;

        public RestaurantController(DataDbContext dataContext,
            IBaseDtoMapper<Restaurant,RestaurantDto> mapper) 
            : base(dataContext)
        {
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestaurantDto>> Get([FromRoute] int id)
        {
            var ent = await _data.Restaurants.FirstAsync(x => x.Id == id);

            return Ok(_mapper.Map(ent));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestaurantDto>>> Get()
        {
            var ent = await _data.Restaurants.ToArrayAsync();

            return Ok(_mapper.Map(ent));
        }
    }
}
