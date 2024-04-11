using API006.DTOs;
using API006.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        [HttpGet("ByDate")]
        public IActionResult GetTransactionsByDate(DateTime? startDate = null, DateTime? endDate = null)
            {
            try
                {
                _logger.LogInformation($"Controller action: Fetching all transactions with date filters.");
                var transactions = _transactionService.GetTransactionsByDate(startDate, endDate);
                if (transactions.Count == 0)
                    {
                    _logger.LogWarning("Controller: No transactions found with the specified date filters.");
                    return NotFound("No transactions found.");
                    }
                return Ok(transactions);
                }
            catch (Exception ex)
                {
                _logger.LogError(ex, "Controller: Error occurred in GetAllTransactions with date filters.");
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
