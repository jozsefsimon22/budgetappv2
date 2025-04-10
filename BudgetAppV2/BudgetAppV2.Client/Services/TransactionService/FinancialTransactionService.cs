
namespace BudgetAppV2.Client.Services.TransactionService;

public class FinancialTransactionService(HttpClient httpClient) : IFinancialTransactionService
{
    public List<FinancialTransaction> FinancialTransactions { get; set; } = [];
    public FinancialTransaction FinancialTransaction { get; set; } = new FinancialTransaction();

    public async Task GetFinancialTransactions()
    {
        var result = await httpClient.GetFromJsonAsync<ServiceResponse<List<FinancialTransaction>>>("api/Transaction");
        if (result is { Data: not null })
        {
            FinancialTransactions = result.Data;
        }
    }

    public async Task GetFinancialTransactionById(Guid id)
    {
        var result = await httpClient.GetFromJsonAsync<ServiceResponse<FinancialTransaction>>($"api/Transaction/{id}");
        if (result is { Data: not null })
        {
            FinancialTransaction = result.Data;
        }
    }

    public async Task<FinancialTransaction> CreateFinancialTransaction(FinancialTransaction financialTransaction)
    {
        var result = await httpClient.PostAsJsonAsync($"api/Transaction", financialTransaction);
        var newFinancialTransaction = (await result.Content.ReadFromJsonAsync<ServiceResponse<FinancialTransaction>>())?.Data;
        return newFinancialTransaction;
    }
}