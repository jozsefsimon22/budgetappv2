namespace BudgetAppV2.Client.Services.TransactionService;

public interface IFinancialTransactionHistoryService
{
    public FinancialTransaction? FinancialTransaction { get; set; }
    Task<FinancialTransaction> CreateFinancialTransactionHistory(Guid financialTransactionId, FinancialTransactionHistory transactionHistory);
    Task GetFinancialTransactionById(Guid id);
}