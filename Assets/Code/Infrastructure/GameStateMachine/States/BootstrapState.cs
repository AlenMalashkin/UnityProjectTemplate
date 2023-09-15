using Code.Infrastructure.StateMachine;
using Code.Services.SceneLoadService;
using Code.Services.StaticDataService;
using Code.UI.LoadingCurtain;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Bootstrap.GameStateMachine.States
{
    public class BootstrapState : IGameState
    {
        private const string SceneName = "Bootstrap";
        
        private IGameStateMachine _gameStateMachine;
        private ISceneLoadService _sceneLoadService;
        private ILoadingCurtain _loadingCurtain;
        private IStaticDataService _staticDataService;
        
        public BootstrapState(IGameStateMachine gameStateMachine, 
            ISceneLoadService sceneLoadService,
            ILoadingCurtain loadingCurtain,
            IStaticDataService staticDataService)
        {
            _gameStateMachine = gameStateMachine;
            _sceneLoadService = sceneLoadService;
            _loadingCurtain = loadingCurtain;
            _staticDataService = staticDataService;
        }
        
        public void Enter()
        {
            _loadingCurtain.Show();
            _staticDataService.Load();
            _sceneLoadService.Load(SceneName, OnLoad);
        }

        public void Exit()
        {
        }

        private void OnLoad()
        {
            _gameStateMachine.Enter<LoadProgressState>();
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, BootstrapState>
        {
        }
    }
}