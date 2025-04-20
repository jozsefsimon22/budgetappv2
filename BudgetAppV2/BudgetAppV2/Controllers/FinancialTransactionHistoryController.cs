using Microsoft.AspNetCore.Mvc;

namespace BudgetAppV2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialTransactionHistoryController(
    IServerFinancialTransactionHistoryService serverFinancialTransactionHistoryService) : ControllerBase
{
    [HttpPost("{id:guid}")]
    public async Task<ActionResult<ServiceResponse<FinancialTransaction>>> PostFinancialTransactionHistory(
        Guid id, FinancialTransactionHistory transactionHistory)
    {
        var result = await serverFinancialTransactionHistoryService.AddHistoryEntryAsync(id, transactionHistory);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ServiceResponse<DateTime>>> GetMinStartDate(Guid id)
    {
        var result = await serverFinancialTransactionHistoryService.GetMinStartDateAsync(id);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<FinancialTransactionHistory>>> UpdateFinancialTransactionHistory(
        FinancialTransactionHistory transactionHistory)
    {
        var result = await serverFinancialTransactionHistoryService.UpdateFinancialTransactionHistory(transactionHistory);
        if (!result.Success)
        {
            return BadRequest(result);
        }
        return Ok(result);
    }
}