using System.ComponentModel.DataAnnotations;

namespace Shared.Entities;

public class FinancialTransactionHistory
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Display(Name = "Amount")]
    public double Amount { get; set; }
    
    public DateOnly StartDate { get; set; }
    
    public DateOnly? EndDate { get; set; }
}