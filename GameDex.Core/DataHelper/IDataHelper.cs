using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.Core.DataHelper
{
    public interface IDataHelper<T>
    {
        Task<T> FindByIDAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> AdvancedSearchAsync(string word);

        void Add(T model);
        void Update(T model);
        void Remove(T model);
    }
}
