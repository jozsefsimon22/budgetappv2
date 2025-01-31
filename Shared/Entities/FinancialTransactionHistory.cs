using System.ComponentModel.DataAnnotations;

namespace Shared.Entities;

public class FinancialTransactionHistory
{
    [Display(Name = "Amount")]
    public double? Amount { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; } = DateTime.Today;
}