using System;
using System.Collections.Generic;
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
            var services = GetServices(item);
            if (services == null)
                return null;

            //Compares all values from the available services
            List<IValue> values = new List<IValue>();
            services.ForEach(x => {
                values.Add(x.CalculateValue(item));
            });
            return values.OrderBy(x => x.Value()).FirstOrDefault();
        }

        private List<IValueService> GetServices<TItem>(TItem item) {
            int priority = -1;
            foreach (var service in _services) {
                foreach (var filter in service.Value) {

                    //If ServiceFilter is for TItem type
                    if (filter.GetType() != typeof(ServiceFilter<TItem>))   
                        continue;

                    //Check if filter is true and if priority is higher
                    if ((filter as ServiceFilter<TItem>).Filter(item) && priority < filter.Priority) {
                        priority = filter.Priority;
                    }
                }
            }

            //Get all services with the highest priority
            var resultServices = new List<IValueService>();
            foreach (var service in _services) {
                if(service.Value.Any(x => x.Priority == priority))
                    resultServices.Add(service.Key);
            }
            return resultServices;
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