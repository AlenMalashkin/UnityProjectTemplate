using Code.Infrastructure.StateMachine;
using Code.Services.SceneLoadService;
using Code.UI.LoadingCurtain;
using Zenject;

namespace Code.Infrastructure.Bootstrap.GameStateMachine.States
{
    public class LoadLevelState : IPayloadedGameState<string>
    {
        private IGameStateMachine _gameStateMachine;
        private ISceneLoadService _sceneLoadService;
        private ILoadingCurtain _loadingCurtain;
        
        public LoadLevelState(IGameStateMachine gameStateMachine,
            ISceneLoadService sceneLoadService,
            ILoadingCurtain loadingCurtain)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoadService = sceneLoadService;
            _loadingCurtain = loadingCurtain;
        }
        
        public void Enter(string payload)
        {
            _sceneLoadService.Load(payload, OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            _loadingCurtain.Hide();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadLevelState>
        {
        }
    }
}