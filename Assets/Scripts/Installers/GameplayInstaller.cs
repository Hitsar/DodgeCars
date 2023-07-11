using Zenject;

namespace Installers
{
    public class GameplayInstaller : MonoInstaller<GameplayInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<InputSystem>().AsSingle();
        }
    }
}