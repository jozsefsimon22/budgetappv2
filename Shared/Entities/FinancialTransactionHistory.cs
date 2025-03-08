using System.ComponentModel.DataAnnotations;

namespace Shared.Entities;

public class FinancialTransactionHistory
{
    [Display(Name = "Amount")]
    public double Amount { get; set; }
    
    public DateOnly StartDate { get; set; }
    
    public DateOnly? EndDate { get; set; }
}