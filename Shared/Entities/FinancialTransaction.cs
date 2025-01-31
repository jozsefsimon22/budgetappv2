using System.ComponentModel.DataAnnotations;
using Shared.Enums;

namespace Shared.Entities;

public class FinancialTransaction
{
    [Key] 
    public Guid Id { get; set; } = Guid.NewGuid();

    public TransactionType TransactionType { get; set; }

    public bool IsRecurring { get; set; }

    public TransactionFrequency TransactionFrequency { get; set; }

    public string Name { get; set; } = string.Empty;

    public double CurrentAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public IEnumerable<FinancialTransactionHistory> History { get; init; } = new List<FinancialTransactionHistory>();
}