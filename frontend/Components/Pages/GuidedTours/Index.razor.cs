namespace frontend.Components.Pages.GuidedTours;

using frontend.Models;

public partial class Index
{
    private IEnumerable<Exhibition> _exhibitions = [];
    private IEnumerable<GuidedTour> _list = [];
    private GuidedTour _guidedtour = new();
    private int DurationHours
    {
        get => _guidedtour.Duration.Hours;
        set => _guidedtour.Duration = new TimeSpan(value, _guidedtour.Duration.Minutes, 0);
    }

    private int DurationMinutes
    {
        get => _guidedtour.Duration.Minutes;
        set => _guidedtour.Duration = new TimeSpan(_guidedtour.Duration.Hours, value, 0);
    }

    private async Task SaveAsync()
    {
        await guidedToursService.InsertAsync(_guidedtour);
        _list = await guidedToursService.GetAllAsync();
        _guidedtour = new();
    }

    //private async Task SaveAsync()
    //{
    //    var result = await guidedToursService.InsertAsync(_guidedtour);
    //    if (result.IsSuccess)
    //    {
    //        _guidedtour = new();
    //        _list = await guidedToursService.GetAllAsync();
    //        StateHasChanged();
    //    }
    //    else
    //    {
    //        // show error
    //    }
    //}

    protected override async Task OnInitializedAsync()
    {
        _exhibitions = await exhibitionsService.GetAllAsync();
        _list = await guidedToursService.GetAllAsync();

        if (_exhibitions.Any())
        {
            _guidedtour.Exhibition = _exhibitions.First().Title;
        }
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
