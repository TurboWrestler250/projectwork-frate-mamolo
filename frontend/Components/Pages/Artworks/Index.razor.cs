namespace frontend.Components.Pages.Artworks
{
    using frontend.Models;
    using frontend.Services;
    public partial class Index(IArtworksService artworksService)
    {
        private IEnumerable<Artwork>? _list;

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(200);
            //_exhibitions = exhibitionsService.GetExhibitions();
            _list = await artworksService.GetAllAsync();
        }

        protected override void OnParametersSet()
        {
            base.OnParametersSet();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            base.OnAfterRender(firstRender);
        }
    }
}
