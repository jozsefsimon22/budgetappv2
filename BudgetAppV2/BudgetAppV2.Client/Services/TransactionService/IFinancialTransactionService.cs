
namespace BudgetAppV2.Client.Services.TransactionService;

public interface IFinancialTransactionService
{
    List<FinancialTransaction> FinancialTransactions { get; set; }
    Task GetFinancialTransactions();
}