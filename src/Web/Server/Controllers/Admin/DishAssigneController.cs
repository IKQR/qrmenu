using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QRCodeMenu.Server.Controllers.Base;
using QRCodeMenu.Server.Data;
using QRCodeMenu.Server.Data.Entities;
using QRCodeMenu.Server.Mappers.Base;
using QRCodeMenu.Shared.Dto;

namespace QRCodeMenu.Server.Controllers.Admin
{
    [Route("api/admin/dish/assigne/{dishId:int}")]
    [ApiController]
    public class DishAssigneController : BaseApiController
    {
        private readonly IBaseDtoMapper<Dish, DishDto> _mapper;
        private readonly IBaseBackMapper<Dish, DishDto> _backMapper;

        public DishAssigneController(
            DataDbContext dataContext,
            IBaseDtoMapper<Dish, DishDto> mapper, IBaseBackMapper<Dish, DishDto> backMapper)
            : base(dataContext)
        {
            this._mapper = mapper;
            _backMapper = backMapper;
        }



        [HttpPost]
        public async Task<IActionResult> Assigne(
            [FromRoute] int dishId,
            [FromBody] int ingredientId)
        {
            var dish = await _data.Dishes.FirstOrDefaultAsync(x => x.Id == dishId);
            var ingredient = await _data.Ingredients.FirstOrDefaultAsync(x => x.Id == ingredientId);

            if(dish is not null && dish?.RestaurantId == ingredient?.RestaurantId )
            {
                dish!.Ingredients.Add(ingredient!);
                _data.Update(dish);
                await _data.SaveChangesAsync();
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UnAssigne(
            [FromRoute] int dishId,
            [FromBody] int ingredientId)
        {
            var dish = await _data.Dishes.FirstOrDefaultAsync(x => x.Id == dishId);
            var ingredient = await _data.Ingredients.FirstOrDefaultAsync(x => x.Id == ingredientId);

            if (dish is not null && dish?.RestaurantId == ingredient?.RestaurantId)
            {
                dish!.Ingredients.Remove(ingredient!);
                _data.Update(dish);
                await _data.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }

    }
}
