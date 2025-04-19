namespace BudgetAppV2.Client.Services.TransactionService;

public class FinancialTransactionHistoryService(HttpClient httpClient) : IFinancialTransactionHistoryService
{
    public FinancialTransaction? FinancialTransaction { get; set; } = null;
    public DateTime? FinancialTransactionHistoryMinDate { get; set; }

    public async Task<FinancialTransaction> CreateFinancialTransactionHistory(Guid financialTransactionId, FinancialTransactionHistory transactionHistory)
    {
        var result = await httpClient.PostAsJsonAsync($"api/FinancialTransactionHistory/{financialTransactionId}", transactionHistory);
        if (!result.IsSuccessStatusCode)
        {
            throw new HttpRequestException($"Error creating financial transaction history: {result.StatusCode}");
        }
        var financialTransaction = (await result.Content.ReadFromJsonAsync<ServiceResponse<FinancialTransaction>>())?.Data;
        
        return financialTransaction;
    }

    public async Task UpdateFinancialTransactionHistory(FinancialTransactionHistory transactionHistory)
    {
        var result = await httpClient.PutAsJsonAsync($"api/FinancialTransactionHistory", transactionHistory);
        
        if (!result.IsSuccessStatusCode)
        {
            var error = await result.Content.ReadAsStringAsync();
            throw new HttpRequestException($"Error updating financial transaction history: {result.StatusCode} - {error}");
        }
        var financialTransaction = (await result.Content.ReadFromJsonAsync<ServiceResponse<FinancialTransaction>>())?.Data;
    }

    public async Task GetFinancialTransactionById(Guid id)
    {
        var result = await httpClient.GetFromJsonAsync<ServiceResponse<FinancialTransaction>>($"api/Transaction/{id}");
        if (result is { Data: not null })
        {
            FinancialTransaction = result.Data;
        }
    }

    public async Task GetFinancialTransactionHistoryMinDate(Guid id)
    {
        var result = await httpClient.GetFromJsonAsync<ServiceResponse<DateTime>>($"api/FinancialTransactionHistory/{id}");
        if (result is { Data: { } dateTime })
        {
            FinancialTransactionHistoryMinDate = dateTime;
        }
    }
}