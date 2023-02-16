using System.Reflection;
using DefaultNamespace.Loaders;
using UnityEngine;

namespace DefaultNamespace.Configs
{
    public class ConfigsService
    {
        private readonly IAssetLoader<BaseConfig> _configLoader;

        public ConfigsService(IAssetLoader<BaseConfig> configLoader)
        {
            _configLoader = configLoader;
        }
        
        public T GetStaticData<T>() where T : BaseConfig
        {
            var name = typeof(T).GetCustomAttribute<ConfigPathAttribute>().Path;
            return (T)_configLoader.Load(name);
        }
    }
}