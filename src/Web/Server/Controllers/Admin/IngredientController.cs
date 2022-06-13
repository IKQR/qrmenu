using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Controllers.Admin
{
    [ApiController]
    [Route("api/[controller]/{restaurantId}")]
    public class IngredientController : BaseApiController
    {
        private readonly IBaseDtoMapper<Ingredient, IngredientDto> _mapper;

        public IngredientController(DataDbContext dataContext,
            IBaseDtoMapper<Ingredient, IngredientDto> mapper)
            : base(dataContext)
        {
            this._mapper = mapper;
        }

        [Obsolete]
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientDto>> Get(
            [FromRoute] int id,
            [FromRoute] int restaurantId)
        {
            var ent = await _data.Ingredients
                .FirstAsync(x => x.Id == id && x.Restaurant.Id == restaurantId);

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

    }
}
