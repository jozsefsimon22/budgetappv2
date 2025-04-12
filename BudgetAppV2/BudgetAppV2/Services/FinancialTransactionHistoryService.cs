namespace BudgetAppV2.Services;

public class FinancialTransactionHistoryService(DataContext dbContext) : IFinancialTransactionHistoryService
{
    public async Task<ServiceResponse<FinancialTransaction>> AddHistoryEntryAsync(Guid transactionId, FinancialTransactionHistory transactionHistory)
    {
        var transaction = await dbContext.FinancialTransactions.Include(h => h.History).FirstOrDefaultAsync(t => t.Id == transactionId);
        if (transaction == null)
        {
            return new ServiceResponse<FinancialTransaction>
            {
                Success = false,
                Message = "The transaction doesn't exist",
            };
        }
        else
        {
            transaction.History.Add(transactionHistory);
            dbContext.Entry(transaction).State = EntityState.Modified;
            dbContext.FinancialTransactionHistories.Add(transactionHistory);
            await dbContext.SaveChangesAsync();
            return new ServiceResponse<FinancialTransaction>()
            {
                Data = transaction
            };
        }
    }

    public Task<List<FinancialTransactionHistory>> GetHistoryForTransactionAsync(Guid transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<ServiceResponse<FinancialTransactionHistory>> GetEntryByIdAsync(Guid historyId)
    {
        throw new NotImplementedException();
    }

    public Task DeleteHistoryEntryAsync(Guid historyId)
    {
        throw new NotImplementedException();
    }
}