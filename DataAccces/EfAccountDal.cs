using System.Linq.Expressions;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccces;

public class EfAccountDal:IAccountDal
{
    public List<Account> GetAll(Expression<Func<Account, bool>>? filter = null)
    {
        using (EfDbContext context = new EfDbContext())
        {
            return filter == null
                ? context.Set<Account>().ToList()
                : context.Set<Account>().Where(filter).ToList();
          
        }
    }

    public void Add(Account entity)
    {
        using (EfDbContext context = new EfDbContext())
        {
            context.Entry(entity).State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void Update(Account entity)
    {
        using (EfDbContext context = new EfDbContext())
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }

    public void Delete(Account entity)
    {
        using (EfDbContext context = new EfDbContext())
        {
            context.Entry(entity).State = EntityState.Deleted;
            context.SaveChanges();
        }
    }
}