using InputService;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    // [SerializeField] private JoystickInput joystick;
        
    public override void InstallBindings()
    {
        // Container.Bind<IInputService>()
        //     .To<JoystickInput>()
        //     .FromInstance(joystick)
        //     .AsSingle();
    }
}