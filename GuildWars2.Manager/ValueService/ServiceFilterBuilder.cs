using System;
using System.Collections.Generic;

namespace GuildWars2.Manager.ValueService
{
    public class ServiceFilterBuilder<TService, TItem> where TService : BaseValueService
    {
        private List<Tuple<Func<TItem, bool>, int>> _filters = new List<Tuple<Func<TItem, bool>, int>>();

        public ServiceFilterBuilder<TService, TItem> AddFilter(Func<TItem, bool> func, int priority)
        {
            var tuple = Tuple.Create(func, priority);
            _filters.Add(tuple);
            return this;
        }

        internal List<Tuple<Func<TItem, bool>, int>> Result()
        {
            return _filters;
        }
    }
}
