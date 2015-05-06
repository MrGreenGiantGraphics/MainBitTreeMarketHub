using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitTreeMarketMain.Model
{
    public interface IRepository<T>
        where T : ShopEntity
    {
        T Add(T entity);
        T Delete(int id);
        T Get(int id);
        T Update(T entity);
        IQueryable<T> Items { get; }
    }
}
