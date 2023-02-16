using System;

namespace DefaultNamespace.Configs
{
    public class ConfigPathAttribute : Attribute
    {
        public string Path { get; }

        public ConfigPathAttribute(string path)
        {
            Path = path;
        }
    }
}