namespace backend.ApiService.Models;

using System.ComponentModel.DataAnnotations;

public class Ticket
{
    public int Id { get; set; } = default!;
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string VisitorName { get; set; } = default!;
    [Required]
    [StringLength(100, MinimumLength = 1)]
    public string VisitorSurname { get; set; } = default!;
    [Required]
    [StringLength(100, MinimumLength = 1)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = default!;
    public string Type { get; set; } = "Full-Price";
    public int Quantity { get; set; } = 1;
    public decimal TotalPrice { get; set; } = 0;
    public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
}
