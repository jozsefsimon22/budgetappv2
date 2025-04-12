using Microsoft.AspNetCore.Mvc;

namespace BudgetAppV2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialTransactionHistoryController(IFinancialTransactionHistoryService financialTransactionHistoryService)
    : ControllerBase
{
    [HttpPost("{id:guid}")]
    public async Task<ActionResult<ServiceResponse<FinancialTransaction>>> PostFinancialTransactionHistory(
        Guid id, FinancialTransactionHistory transactionHistory)
    {
        var result = await financialTransactionHistoryService.AddHistoryEntryAsync(id, transactionHistory);
        return Ok(result);
    }
}