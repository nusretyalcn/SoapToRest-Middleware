using DataAccces;
using Entities;

namespace Business;

public class AccountManager:IAccountService
{
    private IAccountDal _accountDal;

    public AccountManager(IAccountDal accountDal)
    {
        _accountDal = accountDal;
    }

    public List<Account> GetAll()
    {
        return _accountDal.GetAll();
    }

    public void Add(Account account)
    {
        _accountDal.Add(account);
    }
}