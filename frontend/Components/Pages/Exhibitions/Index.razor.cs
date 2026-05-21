namespace frontend.Components.Pages.Exhibitions;

using frontend.Models;
using frontend.Services;

public partial class Index(IExhibitionsService exhibitionsService)
{
    //[Inject]
    //public IExhibitionsService ExhibitionsService { get; set; } = default!;

    private IEnumerable<Exhibition>? _list;

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(200);
        //_exhibitions = exhibitionsService.GetExhibitions();
        _list = await exhibitionsService.GetAllAsync();
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