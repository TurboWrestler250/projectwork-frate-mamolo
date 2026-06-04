namespace frontend.Components.Pages.Tickets;

using frontend.Models;
using frontend.Services;
using Microsoft.AspNetCore.Components.Forms;

public partial class Index(ITicketsService ticketsService)
{
    private EditContext editContext;
    public Ticket Ticket { get; set; } = new();
    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        editContext = new EditContext(Ticket);
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();
    }

    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);
    }

    public async Task CreateTicket()
    {
        await ticketsService.AddTicketAsync(Ticket);
    }
}