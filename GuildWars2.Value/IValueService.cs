using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuildWars2.Value
{
    public interface IValueService<T>
    {
        bool IsApplicable(T item);

        Task<List<ValueResult<T>>> CalculateValue(List<T> entities, bool takeHighestValue);
    }
}
