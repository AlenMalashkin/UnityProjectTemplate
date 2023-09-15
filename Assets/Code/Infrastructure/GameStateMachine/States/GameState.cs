using Code.Infrastructure.StateMachine;
using Zenject;

namespace Code.Infrastructure.Bootstrap.GameStateMachine.States
{
    public class GameState : IGameState
    {
        private IGameStateMachine _gameStateMachine;
        
        public GameState(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        public void Enter()
        {
        }

        public void Exit()
        {
        }

        public class Factory : PlaceholderFactory<IGameStateMachine, GameState>
        {
        }
    }
}