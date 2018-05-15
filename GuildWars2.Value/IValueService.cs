using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Value
{
    public interface IValueService<T>
    {
        bool IsApplicable(T item);

        Task<ValueResult<T>> CalculateValueAsync(T item);

        Task<List<ValueResult<T>>> CalculateValue(List<T> items);
    }
}
