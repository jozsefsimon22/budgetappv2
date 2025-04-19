namespace BudgetAppV2.Services;

public interface IFinancialTransactionHistoryService
{
    Task<ServiceResponse<FinancialTransaction>> AddHistoryEntryAsync(Guid transactionId, FinancialTransactionHistory history);
    Task<List<FinancialTransactionHistory>> GetHistoryForTransactionAsync(Guid transactionId);
    Task<ServiceResponse<FinancialTransactionHistory>> GetEntryByIdAsync(Guid historyId);
    Task<ServiceResponse<DateTime>> GetMinStartDateAsync(Guid transactionId);
    Task<ServiceResponse<FinancialTransactionHistory>> UpdateFinancialTransactionHistory(FinancialTransactionHistory transactionHistory);
    Task DeleteHistoryEntryAsync(Guid historyId);
}