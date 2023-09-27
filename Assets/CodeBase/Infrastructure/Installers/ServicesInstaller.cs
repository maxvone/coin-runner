using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "ServicesInstaller", menuName = "Installers/ServicesInstaller")]
public class ServicesInstaller : ScriptableObjectInstaller<ServicesInstaller>
{
    public override void InstallBindings()
    {
    }
}