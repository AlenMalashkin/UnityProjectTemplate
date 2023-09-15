using Code.Data.Models.ProgressModels;
using Code.Infrastructure.Constants;
using Code.Infrastructure.StateMachine;
using Code.Providers.MenuProvider;
using Code.Services.SaveLoadService;
using Code.Services.SceneLoadService;
using Code.Services.StaticDataService;
using Code.UI.LoadingCurtain;
using Zenject;

namespace Code.Infrastructure.Bootstrap.ProjectContextInstallers
{
    public class GameInstaller : MonoInstaller 
    {
        public override void InstallBindings()
        {
            BindGameBootstrapper();

            BindLoadingCurtain();
            
            BindCoroutineRunner();

            BindGameStateMachine();

            BindSceneLoadService();
            
            BindStaticDataService();
            
            BindPlayerProgressModel();
            
            BindSaveLoadService();
            
            BindMenuEntitiesProvider();
        }

        private void BindGameBootstrapper()
        {
            Container
                .Bind<GameBootstrapper>()
                .FromComponentInNewPrefabResource(InfrastructureResourcesPaths.GameBootstrapper)
                .AsSingle();
        }

        private void BindLoadingCurtain()
        {
            Container
                .BindInterfacesAndSelfTo<LoadingCurtain>()
                .FromComponentInNewPrefabResource(UIResourcesPaths.LoadingCurtain)
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .BindInterfacesAndSelfTo<CoroutineRunner>()
                .FromComponentInNewPrefabResource(InfrastructureResourcesPaths.CoroutineRunner)
                .AsSingle();
        }
        
        private void BindGameStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .FromSubContainerResolve()
                .ByInstaller<GameStateMachineInstaller>()
                .AsSingle();
        }

        private void BindSceneLoadService()
        {
            Container
                .BindInterfacesAndSelfTo<SceneLoadService>()
                .AsSingle();
        }

        private void BindStaticDataService()
        {
            Container
                .BindInterfacesAndSelfTo<StaticDataService>()
                .AsSingle();
        }

        private void BindPlayerProgressModel()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerProgressModel>()
                .AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container
                .BindInterfacesAndSelfTo<SaveLoadService>()
                .AsSingle();
        }

        private void BindMenuEntitiesProvider()
        {
            Container
                .BindInterfacesAndSelfTo<MenuEntitiesProvider>()
                .AsSingle();
        }
    }
}