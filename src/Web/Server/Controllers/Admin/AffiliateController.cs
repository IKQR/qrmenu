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
    public class AffiliateController : BaseApiController
    {
        private readonly IBaseDtoMapper<Affiliate, AffiliateDto> _mapper;
        private readonly IBaseBackMapper<Affiliate, AffiliateDto> _backMapper;

        public AffiliateController(DataDbContext dataContext,
            IBaseDtoMapper<Affiliate, AffiliateDto> mapper, IBaseBackMapper<Affiliate, AffiliateDto> backMapper)
            : base(dataContext)
        {
            _mapper = mapper;
            _backMapper = backMapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AffiliateDto>>> Get()
        {
            var ent = await _data.Affiliate.ToArrayAsync();

            return Ok(_mapper.Map(ent));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AffiliateDto>> Get(
            [FromRoute] int restaurantId, [FromRoute] int id)
        {
            var ent = await _data.Affiliate
                .FirstOrDefaultAsync(x => x.Id == id && x.RestaurantId == restaurantId);

            if (ent is null) return NotFound();

            return _mapper.Map(ent);
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromRoute] int restaurantId, [FromBody] AffiliateDto affiliate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            affiliate.RestaurantId = restaurantId;

            var ent = _backMapper.MapBack(affiliate);

            await _data.Affiliate.AddAsync(ent);
            await _data.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(
            [FromRoute] int restaurantId, [FromBody] AffiliateDto affiliate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            affiliate.RestaurantId = restaurantId;

            var ent = await _data.Affiliate.FirstOrDefaultAsync(x => x.Id == affiliate.Id
                                                                     && x.RestaurantId == restaurantId);
            if (ent is null) return NotFound();

            var entity = _backMapper.MapUpdate(ent, affiliate);
            _data.Affiliate.Update(entity);
            await _data.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(
            [FromRoute] int restaurantId, [FromRoute] int id)
        {
            var affiliate = await _data.Affiliate.FirstOrDefaultAsync(x => x.Id == id
                                                                           && x.RestaurantId == restaurantId);
            if (affiliate is null) return NotFound();

            _data.Affiliate.Remove(affiliate);
            await _data.SaveChangesAsync();
            return Ok(affiliate);
        }

    }
}