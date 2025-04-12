
using Microsoft.AspNetCore.Mvc;


namespace BudgetAppV2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController(IServerFinancialTransactionService serverFinancialTransactionService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<FinancialTransaction>>>> GetTransactions()
    {
        var result = await serverFinancialTransactionService.GetAllTransactionsAsync();

        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ServiceResponse<FinancialTransaction>>> GetTransactionsById(Guid id)
    {
        var result = await serverFinancialTransactionService.GetTransactionByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<FinancialTransaction>>> PostTransaction(
        FinancialTransaction transaction)
    {
        var result = await serverFinancialTransactionService.CreateTransactionAsync(transaction);
        return Ok(result);
    }
}