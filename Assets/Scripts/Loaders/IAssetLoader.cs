namespace DefaultNamespace.Loaders
{
    public interface IAssetLoader<out T> where T : UnityEngine.Object
    {
        T Load(string name);
    }
}