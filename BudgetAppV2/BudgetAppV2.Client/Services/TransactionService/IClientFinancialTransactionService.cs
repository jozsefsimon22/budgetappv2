
namespace BudgetAppV2.Client.Services.TransactionService;

public interface IClientFinancialTransactionService
{
    List<FinancialTransaction> FinancialTransactions { get; set; }
    public FinancialTransaction FinancialTransaction { get; set; } 
    Task GetFinancialTransactions();
    Task GetFinancialTransactionById(Guid id);
    Task<FinancialTransaction> CreateFinancialTransaction(FinancialTransaction financialTransaction);
}