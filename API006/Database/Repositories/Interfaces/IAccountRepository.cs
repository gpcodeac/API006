﻿using API006.Database.Models;

namespace API006.Database.Repositories.Interfaces
{
    public interface IAccountRepository
    {
         Account Withdraw(string accountNumber, int amount);
         Account Delete(string accountNumber);
         Account Deposit(string accountNumber, int amount);
    }
}
