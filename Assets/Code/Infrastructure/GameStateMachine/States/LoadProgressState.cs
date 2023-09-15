using Code.Data.Models.ProgressModels;
using Code.Data.Progress;
using Code.Infrastructure.StateMachine;
using Code.Services.SaveLoadService;
using Code.Services.SceneLoadService;
using Code.UI.LoadingCurtain;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Bootstrap.GameStateMachine.States
{
    public class LoadProgressState : IGameState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly ISaveLoadService _saveLoadService;
        private readonly IPlayerProgressModel _progress;

        public LoadProgressState(IGameStateMachine gameStateMachine, 
            ISaveLoadService saveLoadService, 
            IPlayerProgressModel progress)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _progress = progress;
        }
        
        public void Enter()
        {
            LoadProgressOrInitNew();
            _gameStateMachine.Enter<MenuState, string>("Menu");
        }

        public void Exit()
        {
        }

        private void LoadProgressOrInitNew()
            => _progress.Progress = _saveLoadService.Load() ?? new PlayerProgress();

        public class Factory : PlaceholderFactory<IGameStateMachine, LoadProgressState>
        {
        }
    }
}