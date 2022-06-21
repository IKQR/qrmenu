using Microsoft.AspNetCore.Components;
using QRCodeMenu.Shared.Dto;
using System.Net.Http.Json;

namespace QRCodeMenu.Client.Pages.Admin.Restaurant.Dishes
{
    public partial class IngredientAssigneSelect
    {
        [Inject]
        public HttpClient Http { get; set; }

        [Parameter]
        public DishDto Dish { get; set; } = new();
        [Parameter]
        public IngredientDto[] AssignedIngredients { get; set; } = Array.Empty<IngredientDto>();
        [Parameter]
        public IngredientDto[] NotAssignedIngredients { get; set; } = Array.Empty<IngredientDto>();

        protected long[] devicesToUnassigne = new long[] { };
        protected long[] devicesToAssigne = new long[] { };

        protected async Task UnassigneSelected()
        {
            foreach (var d in devicesToUnassigne)
            {
                var ingredient = AssignedIngredients.FirstOrDefault(x => x.Id == d);
                var result = await Http.PutAsJsonAsync<int>(
                    $"/api/admin/dish/assigne/{Dish.Id}", ingredient.Id);

                if (result.IsSuccessStatusCode)
                {
                    NotAssignedIngredients = NotAssignedIngredients.Concat(new[] { ingredient }).ToArray();
                    AssignedIngredients = AssignedIngredients.Except(new[] { ingredient }).ToArray();
                }
            }
            devicesToUnassigne = Array.Empty<long>();
        }

        protected async Task AssigneSelected()
        {
            foreach (var d in devicesToAssigne)
            {
                var ingredient = NotAssignedIngredients.FirstOrDefault(x => x.Id == d);
                var result = await Http.PostAsJsonAsync<int>(
                    $"/api/admin/dish/assigne/{Dish.Id}", ingredient.Id);

                if (result.IsSuccessStatusCode)
                {
                    AssignedIngredients = AssignedIngredients.Concat(new[] { ingredient }).ToArray();
                    NotAssignedIngredients = NotAssignedIngredients.Except(new[] { ingredient }).ToArray();
                }
            }
            devicesToAssigne = Array.Empty<long>();
        }
    }
}
