using DefaultNamespace.Map;
using DefaultNamespace.Progress;
using InputService;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IProgressService>()
            .To<ProgressService>()
            .AsSingle();
        
        Container.Bind<ISceneObjectsFactory>()
            .To<SceneObjectsFactory>()
            .AsSingle();
    }
}