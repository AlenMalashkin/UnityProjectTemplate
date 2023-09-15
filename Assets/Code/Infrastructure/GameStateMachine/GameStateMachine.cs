using System;
using System.Collections.Generic;
using Code.Infrastructure.Bootstrap.GameStateMachine.States;

namespace Code.Infrastructure.StateMachine
{
    public class GameStateMachine : IGameStateMachine
    {
        private Dictionary<Type, IExitableGameState> _statesMap = new Dictionary<Type, IExitableGameState>();
        
        private IExitableGameState _currentState;

        public GameStateMachine(BootstrapState.Factory bootstrapStateFactory,
            LoadProgressState.Factory loadProgressStateFactory,
            LoadLevelState.Factory loadLevelStateFactory,
            MenuState.Factory menuStateFactory,
            GameState.Factory gameStateFactory)
        {
            RegisterGameState(bootstrapStateFactory.Create(this));
            RegisterGameState(loadProgressStateFactory.Create(this));
            RegisterGameState(loadLevelStateFactory.Create(this));
            RegisterGameState(menuStateFactory.Create(this));
            RegisterGameState(gameStateFactory.Create(this));
        }

        public void Enter<TState>() where TState : class, IGameState
        {
            TState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TPayloadedState, TPayload>(TPayload payload) where TPayloadedState : class, IPayloadedGameState<TPayload>
        {
            TPayloadedState state = ChangeState<TPayloadedState>();
            state.Enter(payload);
        }

        private void RegisterGameState<TState>(TState state) where TState : class, IExitableGameState
            => _statesMap.Add(typeof(TState), state);

        private TState ChangeState<TState>() where TState : class, IExitableGameState
        {
            _currentState?.Exit();

            TState state = GetState<TState>();
            _currentState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableGameState
            => _statesMap[typeof(TState)] as TState;
    }
}