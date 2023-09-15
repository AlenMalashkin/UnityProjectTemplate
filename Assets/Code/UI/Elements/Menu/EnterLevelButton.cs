using Code.Infrastructure.Bootstrap.GameStateMachine.States;
using Code.Infrastructure.StateMachine;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Elements.Menu
{
    public class EnterLevelButton : MonoBehaviour
    {
        [SerializeField] private Button enterLevelButton;
        [SerializeField] private string levelName;
        
        private IGameStateMachine _gameStateMachine;

        [Inject]
        private void Construct(IGameStateMachine gameStateMachine)
        {
            _gameStateMachine = gameStateMachine;
        }
        
        private void OnEnable()
        {
            enterLevelButton.onClick.AddListener(OnEnterLevelButtonPressed);
        }

        private void OnDisable()
        {
            enterLevelButton.onClick.RemoveListener(OnEnterLevelButtonPressed);
        }

        private void OnEnterLevelButtonPressed()
            => _gameStateMachine.Enter<LoadLevelState, string>(levelName);
    }
}