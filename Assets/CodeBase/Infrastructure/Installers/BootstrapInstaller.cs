using CodeBase.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Installers
{
    [CreateAssetMenu(fileName = "BootstrapInstaller", menuName = "Installers/BootstrapInstaller")]
    public class BootstrapInstaller : ScriptableObjectInstaller<BootstrapInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle().NonLazy();
            Container.Bind<GameBootstrap>().AsSingle().NonLazy();
        }
    }
}