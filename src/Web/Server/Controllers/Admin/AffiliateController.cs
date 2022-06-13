using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Dto;
using QRCodeMenu.Server.Dto.Mappers.Base;

namespace QRCodeMenu.Server.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AffiliateController : BaseApiController
    {
        private readonly IBaseDtoMapper<Affiliate, AffiliateDto> _mapper;
    
        public AffiliateController(DataDbContext dataContext, 
            IBaseDtoMapper<Affiliate, AffiliateDto> mapper) : base(dataContext)
        {
            _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AffiliateDto>>> Get()
        {
            var ent = await _data.Affiliate.ToArrayAsync();

            return Ok(_mapper.Map(ent));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AffiliateDto>> Get(
            [FromRoute] int id)
        {
            var ent = await _data.Affiliate
                .FirstAsync(x => x.Id == id);

            return _mapper.Map(ent);
        }
    
    }
}