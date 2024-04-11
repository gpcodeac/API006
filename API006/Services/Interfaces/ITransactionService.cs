using API006.DTOs;

namespace API006.Services.Interfaces
    {
    public interface ITransactionService
        {
        List<TransactionDto> GetAllTransactions();
        TransactionDto CreateTransaction(TransactionDto transactionDto);
        List<TransactionDto> GetTransactionsByDate(DateTime? startDate = null, DateTime? endDate = null);
        }
    }
