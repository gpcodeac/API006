using API006.DTOs;
using API006.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API006.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly ILogger<TransactionController> _logger;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger)
        {
            _transactionService = transactionService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            try
            {
                _logger.LogInformation("Controller action GetAllTransactions called.");
                var transactions = _transactionService.GetAllTransactions();
                if (transactions.Count == 0)
                {
                    _logger.LogWarning("No transactions found.");
                    return NotFound();
                }

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in GetAllTransactions.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("ByDate/{date}")]
        public IActionResult GetTransactionsByDate(DateTime date)
        {
            try
            {
                _logger.LogInformation(
                    $"Controller action GetTransactionsByDate called for date: {date.ToShortDateString()}.");
                var transactions = _transactionService.GetTransactionsByDate(date);
                if (transactions.Count == 0)
                {
                    _logger.LogWarning($"No transactions found for date: {date.ToShortDateString()}.");
                    return NotFound();
                }

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred in GetTransactionsByDate for date: {date.ToShortDateString()}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public IActionResult CreateTransaction([FromBody] TransactionDto transactionDto)
        {
            try
            {
                _logger.LogInformation("Controller action CreateTransaction called.");
                var createdTransaction = _transactionService.CreateTransaction(transactionDto);
                return Ok(createdTransaction);
            }


            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in CreateTransaction.");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}