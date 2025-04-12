namespace BudgetAppV2.Services;

public interface IServerFinancialTransactionService
{
    public Task<ServiceResponse<FinancialTransaction>> CreateTransactionAsync(FinancialTransaction transaction);
    public Task<ServiceResponse<List<FinancialTransaction>>> GetAllTransactionsAsync();
    public Task<ServiceResponse<FinancialTransaction>> GetTransactionByIdAsync(Guid id);
    public Task<ServiceResponse<FinancialTransaction>> UpdateTransactionAsync(FinancialTransaction transaction);
    public Task<ServiceResponse<FinancialTransaction>> DeleteTransactionAsync(Guid id);
}
