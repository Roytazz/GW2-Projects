using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace GuildWars2.Manager.ValueService
{
    class ServiceFilterComparer
    {
        private Dictionary<IValueService, List<IBaseServiceFilter>> _services = new Dictionary<IValueService, List<IBaseServiceFilter>>();

        internal void Add<TService, TItem>(Func<TItem, bool> func, int priority) where TService : BaseValueService, new()
        {
            if (!_services.Keys.Any(c => c.GetType() == typeof(TService))) {
                _services.Add(new TService(), new List<IBaseServiceFilter>());
            }
            _services[_services.Keys.FirstOrDefault(c => c.GetType() == typeof(TService))].Add(new ServiceFilter<TItem> { Filter = func, Priority = priority });
        }

        internal IValue CalculateValue<TItem>(TItem item) {
            return GetService(item)?.CalculateValue(item);
        }

        private IValueService GetService<TItem>(TItem item) {
            int priority = -1;
            IValueService resultService = null;

            foreach (var service in _services) {
                foreach (var filter in service.Value) {

                    //If ServiceFilter is for TItem type
                    if (filter.GetType() != typeof(ServiceFilter<TItem>))   
                        continue;

                    //Check if filter is true. If true compare priority and take highest
                    if ((filter as ServiceFilter<TItem>).Filter(item)) {

                        //Found new one
                        if (priority < filter.Priority) {
                            priority = filter.Priority;
                            resultService = service.Key;
                        }
                        else if (priority == filter.Priority)
                            Debug.WriteLine("FOUND EQUAL PRIORITY - NOT GOOD!");
                    }
                }
            }
            return resultService;
        }
    }

    class ServiceFilter<TItem> : IBaseServiceFilter
    {
        public int Priority { get; set; }
        public Func<TItem, bool> Filter { get; set; }
    }

    interface IBaseServiceFilter
    {
        int Priority { get; set; }
    }
}