namespace BudgetAppV2.Services;

public interface IServerFinancialTransactionService
{
    public Task<ServiceResponse<List<FinancialTransaction>>> GetAllTransactionsAsync();
    public Task<ServiceResponse<FinancialTransaction>> GetTransactionAsync(Guid id);
    public Task<ServiceResponse<FinancialTransaction>> CreateTransactionAsync(FinancialTransaction transaction);
}
