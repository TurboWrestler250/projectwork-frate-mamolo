namespace frontend.Components.Pages.Exhibitions;

using frontend.Models;
using frontend.Services;
using Microsoft.AspNetCore.Components;

public partial class Details(IExhibitionsService exhibitionsService)
{
    private Exhibition? _exhibition;

    [Parameter]
    public int Id { get; set; }

    //protected override void OnInitialized()
    //{
    //    _product = productsService.GetProduct(Id);
    //}
    protected override async Task OnInitializedAsync()
    {
        _exhibition = await exhibitionsService.GetItemByIdAsync(Id);
    }
}
