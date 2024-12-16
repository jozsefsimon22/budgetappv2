using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.Entities;

public class FinancialTransaction
{
    [Key]
    public Guid Id { get; set; }

    public TransactionType TransactionType { get; set; }

    public bool IsRecurring { get; set; }

    public TransactionFrequency TransactionFrequency { get; set; }
    
    public string? Name { get; set; }

    public double? Amount { get; set; }

    public DateTime StartDate { get; set; } = DateTime.Today;

    public DateTime? EndDate { get; set; }
}