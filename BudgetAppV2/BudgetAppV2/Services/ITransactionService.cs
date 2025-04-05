namespace BudgetAppV2.Services;

public interface ITransactionService
{
    public Task<ServiceResponse<List<FinancialTransaction>>> GetAllTransactionsAsync();
}
