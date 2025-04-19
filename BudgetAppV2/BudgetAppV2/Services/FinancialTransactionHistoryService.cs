namespace BudgetAppV2.Services;

public class FinancialTransactionHistoryService(DataContext dbContext) : IFinancialTransactionHistoryService
{
    public async Task<ServiceResponse<FinancialTransaction>> AddHistoryEntryAsync(Guid transactionId,
        FinancialTransactionHistory transactionHistory)
    {
        var transaction = await dbContext.FinancialTransactions.Include(h => h.History)
            .FirstOrDefaultAsync(t => t.Id == transactionId);
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

    public async Task<ServiceResponse<DateTime>> GetMinStartDateAsync(Guid transactionId)
    {
        var transaction = await dbContext.FinancialTransactions.Include(h => h.History)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == transactionId);
        if (transaction == null)
        {
            return new ServiceResponse<DateTime>
            {
                Success = false,
                Message = "The transaction doesn't exist",
            };
        }

        // Return new datetime object with MinValue
        if (transaction.History.Count is 0)
            return new ServiceResponse<DateTime>()
            {
                Data = new DateTime()
            };

        var minStartDate = transaction.History.Max(h => h.StartDate).ToDateTime(TimeOnly.MinValue);

        return new ServiceResponse<DateTime>()
        {
            Data = minStartDate
        };
    }

    public async Task<ServiceResponse<FinancialTransactionHistory>> UpdateFinancialTransactionHistory(FinancialTransactionHistory history)
    {
        var historyEntry = history ?? throw new ArgumentNullException(nameof(history));

        var existingEntry = await dbContext.FinancialTransactionHistories
            .FirstOrDefaultAsync(h => h.Id == historyEntry.Id);

        if (existingEntry == null)
        {
            return new ServiceResponse<FinancialTransactionHistory>
            {
                Success = false,
                Message = "History entry not found"
            };
        }
        
        existingEntry.StartDate = historyEntry.StartDate;
        existingEntry.EndDate = historyEntry.EndDate;
        existingEntry.Amount = historyEntry.Amount;

        try
        {
            dbContext.Entry(existingEntry).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return new ServiceResponse<FinancialTransactionHistory>
            {
                Success = false,
                Message = $"Update failed: {ex.Message}"
            };
        }

        return new ServiceResponse<FinancialTransactionHistory>()
        {
            Data = historyEntry
        };
    }

    public Task DeleteHistoryEntryAsync(Guid historyId)
    {
        throw new NotImplementedException();
    }
}