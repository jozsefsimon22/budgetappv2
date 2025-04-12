namespace BudgetAppV2.Client.Services.TransactionService;

public class FinancialTransactionHistoryService(HttpClient httpClient) : IFinancialTransactionHistoryService
{
    public FinancialTransaction? FinancialTransaction { get; set; } = null;

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
    
    public async Task GetFinancialTransactionById(Guid id)
    {
        var result = await httpClient.GetFromJsonAsync<ServiceResponse<FinancialTransaction>>($"api/Transaction/{id}");
        if (result is { Data: not null })
        {
            FinancialTransaction = result.Data;
        }
    }
}