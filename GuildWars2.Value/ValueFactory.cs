using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GuildWars2.Value
{
    public static class ValueFactory
    {
        public static async Task<ValueResult<TItem>> CalculateValue<TItem>(TItem item, bool takeHighestValue = true) {
            var result = await CalculateValue(new List<TItem>() { item }, takeHighestValue);
            return result?.FirstOrDefault();
        }

        public static async Task<List<ValueResult<TItem>>> CalculateValue<TItem>(List<TItem> items, bool calculateHighestValue = true) {
            List<ValueResult<TItem>> correctValues = new List<ValueResult<TItem>>();    

            foreach (var service in FindServices<TItem>()) {
                var serviceObj = ((IValueService<TItem>)Activator.CreateInstance(service));
                if (serviceObj == null)
                    continue;

                var values = await serviceObj.CalculateValue(items);
                foreach (var value in values) {
                    if(correctValues.Any(x => x.Item.GetHashCode() == value.Item.GetHashCode())) {

                        var existingValue = correctValues.Find(x => x.Item.GetHashCode() == value.Item.GetHashCode());
                        if((calculateHighestValue && value.Value.CompareTo(existingValue.Value) == 1)
                                || (!calculateHighestValue && value.Value.CompareTo(existingValue.Value) == -1)) {
                            correctValues.Remove(existingValue);
                            correctValues.Add(value);
                        }
                    }
                    else {
                        correctValues.Add(value);
                    }
                }
            }
            return correctValues;
        }

        private static List<Type> FindServices<TItem>() {
            var services =  AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IValueService<TItem>).IsAssignableFrom(p) && !p.IsInterface);
            return services.ToList();
        }
    }
}