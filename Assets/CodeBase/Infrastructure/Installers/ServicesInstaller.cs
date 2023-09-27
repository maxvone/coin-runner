using CodeBase.Services.Input;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ServicesInstaller", menuName = "Installers/ServicesInstaller")]
public class ServicesInstaller : ScriptableObjectInstaller<ServicesInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IInputService>().To<InputService>().AsSingle();
    }
}