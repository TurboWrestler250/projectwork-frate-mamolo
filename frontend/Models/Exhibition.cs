namespace frontend.Models;

public class Exhibition
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public DateOnly StartDate { get; set; }
    public DateOnly FinishDate { get; set; }
    public string ImageUrl { get; set; } = default!;
    public string Status { get; set; } = default!;
}
