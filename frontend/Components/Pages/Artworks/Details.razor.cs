using frontend.Models;
using frontend.Services;
using Microsoft.AspNetCore.Components;

namespace frontend.Components.Pages.Artworks
{
    public partial class Details(IArtworksService artworksService)
    {
        private Artwork? _artwork;

        [Parameter]
        public int Id { get; set; }

        //protected override void OnInitialized()
        //{
        //    _product = productsService.GetProduct(Id);
        //}
        protected override async Task OnInitializedAsync()
        {
            _artwork = await artworksService.GetItemByIdAsync(Id);
        }
    }

}
