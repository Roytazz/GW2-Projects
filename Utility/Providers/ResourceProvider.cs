using System;
using System.Collections.Generic;
using System.Linq;
using Utility.Logger;

namespace Utility.Providers
{
    public class ResourceProvider
    {
        private static Dictionary<Type, object> _providers;

        private static int CAPACITY = 1000;

        private static ResourceProvider _instance;
        private static object lockObj = new object();

        public static ResourceProvider Instance
        {
            get {
                if (_instance == null) {
                    lock (lockObj) {
                        if (_instance == null)
                            _instance = new ResourceProvider();
                    }
                }
                return _instance;
            }
        }

        public ResourceProvider() {
            _providers = new Dictionary<Type, object>();
        }

        public T GetResource<T>(int ID) {
            var provider = GetProvider<T>();
            if (provider != null)
                return provider.Get(ID);

            return default(T);
        }

        public List<T> GetResource<T>(List<int> IDs) {
            if (IDs.Count > 0) {
                var provider = GetProvider<T>();
                if (provider != null)
                    return provider.Get(IDs);
            }

            return default(List<T>);
        }

        public T GetResource<T>(string identifier) {
            var provider = GetProvider<T>();
            if (provider != null)
                return provider.Get(identifier);

            return default(T);
        }

        public List<T> GetResource<T>(List<string> identifiers) {
            if (identifiers.Count > 0) {
                var provider = GetProvider<T>();
                if (provider != null)
                    return provider.Get(identifiers);
            }
            return default(List<T>);
        }

        private IResourceProvider<T> GetProvider<T>() {
            if (!_providers.ContainsKey(typeof(T))) {
                var providerType = GetProviderType<T>();
                if (providerType != null) {
                    AddProvider<T>(providerType);
                }
                else {
                    LogManager.LogMessage(string.Format("No ResourceProvider found for type: {0}", typeof(T)), false);
                    return null;
                }
            }
            return _providers[typeof(T)] as IResourceProvider<T>;
        }

        private void AddProvider<T>(Type providerType) {
            var provider = Activator.CreateInstance(providerType) as IResourceProvider<T>;
            provider.Capacity = CAPACITY;

            _providers.Add(typeof(T), provider);
        }

        private Type GetProviderType<T>() {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IResourceProvider<T>).IsAssignableFrom(p) && !p.IsInterface);

            if (types.Count() > 0)
                return types.First();

            return null;
        }
    }
}
