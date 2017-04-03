using System.Collections.Generic;
using System;

namespace GuildWars2.Manager.ValueService
{
    public class ValueFactory
    {
        private ServiceFilterComparer _comparer = new ServiceFilterComparer();

        public IValue Value<TItem>(TItem item)
        {
            return _comparer.CalculateValue(item);
        }

        #region Registers
        public void RegisterService<TService, TItem>(Func<TItem, bool> func, int priority) where TService : BaseValueService, new()
        { 
            _comparer.Add<TService, TItem>(func, priority);
        }

        public void RegisterService<TService, TItem>(ServiceFilterBuilder<TService, TItem> builder) where TService : BaseValueService, new() {
            RegisterService<TService, TItem>(builder.Result());
        }

        private void RegisterService<TService, TItem>(IEnumerable<Tuple<Func<TItem, bool>, int>> filters) where TService : BaseValueService, new() {
            foreach (var filter in filters) {
                RegisterService<TService, TItem>(filter.Item1, filter.Item2);
            }
        }
        #endregion Registers
    }
}