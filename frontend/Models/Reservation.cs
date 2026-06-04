using System.ComponentModel.DataAnnotations;

namespace frontend.Models;

public class Reservation
{
    public int Id { get; set; }
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
    [Range(1, 100)]
    public int NumberOfPeople { get; set; } = 1;
    [Required]
    [DataType(DataType.Date)]
    public DateTime Date { get; set; }
    [Required]
    [RegularExpression("^(Confermed|Pending|Denied)$")]
    public string Status { get; set; } = "Pending";
}
