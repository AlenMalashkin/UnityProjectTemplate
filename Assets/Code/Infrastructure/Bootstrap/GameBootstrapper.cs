using System;
using Code.Infrastructure.Bootstrap.GameStateMachine.States;
using Code.Infrastructure.StateMachine;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Bootstrap
{
    public class GameBootstrapper : MonoBehaviour
    {
        private IGameStateMachine _gameStateMachine;
        
        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        private void Awake()
        {
            _gameStateMachine.Enter<BootstrapState>();
        }
    }
}
