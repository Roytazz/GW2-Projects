using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace GuildWars2.Value
{
    public static class ValueFactory
    {
        public static async Task<List<ValueResult<TItem>>> CalculateValue<TItem>(List<TItem> items, bool takeHighestValue = true) {
            List<ValueResult<TItem>> correctValues = new List<ValueResult<TItem>>();

            foreach (var service in FindServices<TItem>()) {
                var serviceObj = (IValueService<TItem>)Activator.CreateInstance(service);
                if (serviceObj == null)
                    continue;

                items = items.Where(x => serviceObj.IsApplicable(x)).ToList();
                var valueResults = await serviceObj.CalculateValue(items, takeHighestValue);
                foreach (var result in valueResults) {
                    if (correctValues.Any(x => x.Item.GetHashCode() == result.Item.GetHashCode())) {
                        var existingValue = correctValues.Find(x => x.Item.GetHashCode() == result.Item.GetHashCode());
                        if (result.Value == null)
                            continue;

                        else if ((takeHighestValue && result.Value > existingValue.Value)
                                || (!takeHighestValue && result.Value < existingValue.Value)) {
                            correctValues.Remove(existingValue);
                            correctValues.Add(result);
                        }
                    }
                    else {
                        correctValues.Add(result);
                    }
                }
            }
            return correctValues;
        }

        private static List<Type> FindServices<TItem>() {
            LoadAssemblies();
            var services = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IValueService<TItem>).IsAssignableFrom(p) && !p.IsInterface);
            return services.GroupBy(x => x.GUID).Select(x => x.First()).ToList();
        }

        private static void LoadAssemblies() {
            List<Assembly> allAssemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "*.dll")) {
                var assembly = Assembly.LoadFile(dll);
                if (!allAssemblies.Contains(assembly)) {
                    allAssemblies.Add(assembly);
                    AppDomain.CurrentDomain.Load(assembly.FullName);
                }
            }
        }
    }
}