namespace BudgetAppV2.Services;

public class ServerServerFinancialTransactionService(DataContext context) : IServerFinancialTransactionService
{
    public async Task<ServiceResponse<List<FinancialTransaction>>> GetAllTransactionsAsync()
    {
        var transactions = await context.FinancialTransactions.ToListAsync();
        var response = new ServiceResponse<List<FinancialTransaction>>()
        {
            Data = transactions
        };
        return response;
    }

    public async Task<ServiceResponse<FinancialTransaction>> GetTransactionAsync(Guid id)
    {
        var response = new ServiceResponse<FinancialTransaction>();
        var transaction = await context.FinancialTransactions.Include(t => t.History)
            .FirstOrDefaultAsync(t => t.Id == id);
        if (transaction == null)
        {
            response.Success = false;
            response.Message = "Transaction not found";
        }
        else
        {
            response = new ServiceResponse<FinancialTransaction>()
            {
                Data = transaction
            };
        }

        return response;
    }

    public async Task<ServiceResponse<FinancialTransaction>> CreateTransactionAsync(FinancialTransaction transaction)
    {
        context.FinancialTransactions.Add(transaction);
        await context.SaveChangesAsync();
        return new ServiceResponse<FinancialTransaction>()
        {
            Data = transaction
        };
    }
}