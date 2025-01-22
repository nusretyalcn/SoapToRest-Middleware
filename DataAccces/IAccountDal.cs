using System.Linq.Expressions;
using Entities;

namespace DataAccces;

public interface IAccountDal
{
    public List<Account> GetAll(Expression<Func<Account, bool>> filter = null);
    public void Add(Account entity);
    public void Update(Account entity);
    public void Delete(Account entity);
}