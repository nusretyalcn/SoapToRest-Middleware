using Entities;

namespace Business;

public interface IAccountService
{
    public List<Account> GetAll();
    public void Add(Account account);
}