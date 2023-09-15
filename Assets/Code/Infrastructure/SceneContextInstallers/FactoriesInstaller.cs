using Code.Infrastructure.Bootstrap.Factories;
using Code.UI.Factories;
using Zenject;

namespace Code.Infrastructure.Bootstrap.SceneContextInstallers
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindGameFactory();
            
            BindUIFactory();
        }

        private void BindGameFactory()
        {
            Container
                .BindInterfacesAndSelfTo<GameFactory>()
                .AsSingle();
        }

        private void BindUIFactory()
        {
            Container
                .BindInterfacesAndSelfTo<UIFactory>()
                .AsSingle();
        }
    }
}