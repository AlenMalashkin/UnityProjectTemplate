using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Bootstrap
{
    public class GameRunner : MonoBehaviour
    {
        private DiContainer _diContainer;
        private GameBootstrapper _gameBootstrapper;

        [Inject]
        private void Construct(DiContainer diContainer, GameBootstrapper gameBootstrapper)
        {
            _diContainer = diContainer;
            _gameBootstrapper = gameBootstrapper;
        }
        
        private void Awake()
        {
            GameBootstrapper gameBootstrapper = FindObjectOfType<GameBootstrapper>();

            if (gameBootstrapper != null)
                return;

            _diContainer.InstantiatePrefab(_gameBootstrapper);
        }
    }
}

