using CockroachDbLib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CockroachDbLib.Repository
{
    public interface IAccountRepository
    {
        List<Account> GetAllAccounts();

        Task<Account> GetAccountById(int? id);

        Task<Account> CreateAccount(Account account);

        int GetLastAccountId();

        void UpdateAccount(Account account);

        Task<string> DeleteAccount(int? id);
    }
}