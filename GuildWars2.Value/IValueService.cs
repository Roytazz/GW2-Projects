using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2.Value
{
    public interface IValueService<T>
    {
        bool IsApplicable(T item);

        Task<ValueResult<T>> CalculateValue(T item, bool takeHighestValue);

        Task<List<ValueResult<T>>> CalculateValue(List<T> items, bool takeHighestValue);
    }
}
