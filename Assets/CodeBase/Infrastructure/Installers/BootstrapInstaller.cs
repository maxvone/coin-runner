using CodeBase.Infrastructure;
using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BootstrapInstaller", menuName = "Installers/BootstrapInstaller")]
public class BootstrapInstaller : ScriptableObjectInstaller<BootstrapInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle().NonLazy();
        Container.Bind<GameBootstrap>().AsSingle().NonLazy();
    }
}