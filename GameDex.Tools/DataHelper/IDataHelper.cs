using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDex.Tools.DataHelper
{
    public interface IDataHelper<T>
    {
        Task<T> GetByIDAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> GetAllForDisplayAsync(int id);
        Task<List<T>> AdvancedSearchAsync(string word);

        void Add(T model);
        void Update(T model);
        void Remove(T model);
    }
}
