
namespace BudgetAppV2.Client.Services.TransactionService;

public class FinancialTransactionService(HttpClient httpClient) : IFinancialTransactionService
{
    public List<FinancialTransaction> FinancialTransactions { get; set; } = [];

    public async Task GetFinancialTransactions()
    {
        var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<FinancialTransaction>>>("api/Transaction");
        if (result is { Data: not null })
        {
            FinancialTransactions = result.Data;
        }
    }
}