using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using QRCodeMenu.Shared.Dto;
using System.Net.Http.Json;
using static QRCodeMenu.Client.Components.Diver;

namespace QRCodeMenu.Client.Pages.Admin
{
    public partial class RestaurantChildBaseComponent
    {
        [Inject]
        protected HttpClient Http { get; init; } = null!;
        [Inject]
        protected IJSRuntime JSRuntime { get; init; } = null!;

        [Parameter]
        public int RestaurantId { get; set; } = 0;
        protected RestaurantDto Restaurant { get; set; } = new();

        protected virtual DiverItem[] DiverItems => new DiverItem[] {
            new("Restaurants", "/admin/restaurant"),
            new(Restaurant.Name, $"/admin/restaurant/{Restaurant.Id}"),
        };

        protected override async Task OnInitializedAsync()
        {
            await LoadRestaurant();
            await LoadOnInitialized();

            await base.OnInitializedAsync();
        }

        protected virtual async Task LoadOnInitialized()
        {
            await Task.CompletedTask;
        }

        protected async Task LoadRestaurant()
        {
            var result =
                await Http.GetFromJsonAsync<RestaurantDto>(
                    $"/api/admin/restaurant/{RestaurantId}")
                ?? new();

            Restaurant = result;
        }
    }
}
