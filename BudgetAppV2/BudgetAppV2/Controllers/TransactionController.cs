using Microsoft.AspNetCore.Mvc;


namespace BudgetAppV2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private static readonly List<FinancialTransaction> Transactions =
    [
        new FinancialTransaction
        {
            Id = Guid.NewGuid(),
            TransactionType = TransactionType.Expense,
            IsRecurring = true,
            TransactionFrequency = TransactionFrequency.Monthly,
            Name = "Netflix Subscription",
            CurrentAmount = 15.99,
            StartDate = new DateOnly(2023, 1, 1),
            EndDate = null
        },

        new FinancialTransaction
        {
            Id = Guid.NewGuid(),
            TransactionType = TransactionType.Income,
            IsRecurring = true,
            TransactionFrequency = TransactionFrequency.Monthly,
            Name = "Salary",
            CurrentAmount = 2500.00,
            StartDate = new DateOnly(2022, 6, 15),
            EndDate = null
        },

        new FinancialTransaction
        {
            Id = Guid.NewGuid(),
            TransactionType = TransactionType.Expense,
            IsRecurring = false,
            TransactionFrequency = TransactionFrequency.OneTime,
            Name = "New Laptop",
            CurrentAmount = 1200.00,
            StartDate = new DateOnly(2024, 2, 10),
            EndDate = new DateOnly(2024, 2, 10)
        },

        new FinancialTransaction
        {
            Id = Guid.NewGuid(),
            TransactionType = TransactionType.Income,
            IsRecurring = false,
            TransactionFrequency = TransactionFrequency.OneTime,
            Name = "Freelance Project",
            CurrentAmount = 800.00,
            StartDate = new DateOnly(2024, 1, 15),
            EndDate = null
        },

        new FinancialTransaction
        {
            Id = Guid.NewGuid(),
            TransactionType = TransactionType.Expense,
            IsRecurring = true,
            TransactionFrequency = TransactionFrequency.Monthly,
            Name = "Gym Membership",
            CurrentAmount = 25.00,
            StartDate = new DateOnly(2023, 3, 1),
            EndDate = null
        },

        new FinancialTransaction
        {
            Id = Guid.NewGuid(),
            TransactionType = TransactionType.Expense,
            IsRecurring = false,
            TransactionFrequency = TransactionFrequency.OneTime,
            Name = "Concert Tickets",
            CurrentAmount = 150.00,
            StartDate = new DateOnly(2024, 5, 20),
            EndDate = new DateOnly(2024, 5, 20)
        }
    ];

    [HttpGet]
    public async Task<ActionResult<List<FinancialTransaction>>> GetTransactions()
    {
        return Ok(Transactions);
    }
}