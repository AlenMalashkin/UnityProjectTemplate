using Code.Infrastructure.Bootstrap.GameStateMachine.States;

namespace Code.Infrastructure.StateMachine
{
    public interface IGameStateMachine
    {
        void Enter<TState>() where TState : class, IGameState;
        void Enter<TPayloadedState, TPayload>(TPayload payload) where TPayloadedState : class, IPayloadedGameState<TPayload>;
    }
}