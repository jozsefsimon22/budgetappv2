namespace BudgetAppV2.Services;

public class ServerServerFinancialTransactionService(DataContext dbContext) : IServerFinancialTransactionService
{
    public async Task<ServiceResponse<FinancialTransaction>> CreateTransactionAsync(FinancialTransaction transaction)
    {
        dbContext.FinancialTransactions.Add(transaction);
        await dbContext.SaveChangesAsync();
        return new ServiceResponse<FinancialTransaction>()
        {
            Data = transaction
        };
    }
    public async Task<ServiceResponse<List<FinancialTransaction>>> GetAllTransactionsAsync()
    {
        var transactions = await dbContext.FinancialTransactions.ToListAsync();
        var response = new ServiceResponse<List<FinancialTransaction>>()
        {
            Data = transactions
        };
        return response;
    }

    public async Task<ServiceResponse<FinancialTransaction>> GetTransactionByIdAsync(Guid id)
    {
        var response = new ServiceResponse<FinancialTransaction>();
        var transaction = await dbContext.FinancialTransactions.Include(t => t.History)
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

    public Task<ServiceResponse<FinancialTransaction>> UpdateTransactionAsync(FinancialTransaction transaction)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<FinancialTransaction>> DeleteTransactionAsync(Guid id)
    {
        throw new NotImplementedException();
    }


}