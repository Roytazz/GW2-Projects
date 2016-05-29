using GuildWars2API.Model.Commerce;
using GuildWars2API.Model.Items;
using GuildWars2Guild.Classes.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildWars2Guild.Classes.Resources
{
    public class ResourceManager
    {
        private static Dictionary<Type, object> _providers = new Dictionary<Type, object>();
        private static ResourceManager _resourceManager;

        public static ResourceManager Instance {
            get {
                if(_resourceManager == null)
                    _resourceManager = new ResourceManager();

                return _resourceManager;
            }
        }

        public T GetResource<T>(int ID) {
            var provider = GetProvider<T>();
            if(provider != null) 
                return provider.Get(ID);

            return default(T);
        }

        public List<T> GetResource<T>(List<int> IDs) {
            var provider = GetProvider<T>();
            if(provider != null)
                return provider.Get(IDs);

            return default(List<T>);
        }

        private IResourceProvider<T> GetProvider<T>() {
            if(!_providers.ContainsKey(typeof(T))) {
                var providerType = GetProviderType<T>();
                if(providerType != null) {
                    _providers.Add(typeof(T), Activator.CreateInstance(providerType));
                }
                else {
                    Logger.LogManager.LogMessage(string.Format("No ResourceProvider found for type: {0}", typeof(T)));
                }
            }

            return _providers[typeof(T)] as IResourceProvider<T>;
        }

        private void AddProvider<T, K>(K provider) where T : class where K : IResourceProvider<T> {
            if(_providers == null)
                _providers = new Dictionary<Type, object>();

            _providers.Add(typeof(T), provider);
        }

        private Type GetProviderType<T>() {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IResourceProvider<T>).IsAssignableFrom(p)).First();
        }
    }
}
