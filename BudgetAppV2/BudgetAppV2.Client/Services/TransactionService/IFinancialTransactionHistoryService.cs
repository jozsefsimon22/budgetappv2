namespace BudgetAppV2.Client.Services.TransactionService;

public interface IFinancialTransactionHistoryService
{
    public FinancialTransaction? FinancialTransaction { get; set; }
    public DateTime? FinancialTransactionHistoryMinDate { get; set; }

    Task<FinancialTransaction> CreateFinancialTransactionHistory(Guid financialTransactionId, FinancialTransactionHistory transactionHistory);
    Task UpdateFinancialTransactionHistory(FinancialTransactionHistory transactionHistory);
    Task GetFinancialTransactionById(Guid id);
    Task GetFinancialTransactionHistoryMinDate(Guid financialTransactionId);
}