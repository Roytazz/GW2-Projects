using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildWars2.API.Providers
{
    [Obsolete]
    public class ResourceProvider
    {
        private static int CAPACITY = 1000;
        private static Dictionary<Type, object> _providers = new Dictionary<Type, object>();

        #region Getters
        public T GetResource<T>(int ID) {
            var provider = GetProvider<T>();
            if (provider != null)
                return provider.Get(ID);

            return default(T);
        }

        public List<T> GetResource<T>(List<int> IDs) {
            var provider = GetProvider<T>();
            if (provider != null)
                return provider.Get(IDs);
            
            return default(List<T>);
        }

        public T GetResource<T>(string identifier) {
            var provider = GetProvider<T>();
            if (provider != null)
                return provider.Get(identifier);

            return default(T);
        }

        public List<T> GetResource<T>(List<string> identifiers) {
            var provider = GetProvider<T>();
            if (provider != null)
                return provider.Get(identifiers);

            return default(List<T>);
        }
        #endregion Getters

        private IResourceProvider<T> GetProvider<T>() {
            if (!_providers.ContainsKey(typeof(T))) {
                var providerType = SearchProviderType<T>();
                if (providerType == null) 
                    return null;

                AddProvider<T>(providerType);
            }
            return _providers[typeof(T)] as IResourceProvider<T>;
        }

        private Type SearchProviderType<T>() {
            var type = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .FirstOrDefault(p => typeof(IResourceProvider<T>).IsAssignableFrom(p) && !p.IsInterface);

            return type;
        }

        private void AddProvider<T>(Type providerType) {
            var provider = Activator.CreateInstance(providerType) as IResourceProvider<T>;
            provider.Capacity = CAPACITY;
            _providers.Add(typeof(T), provider);
        }
    }
}