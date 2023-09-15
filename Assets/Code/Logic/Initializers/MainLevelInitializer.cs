using Code.Infrastructure.Bootstrap.Factories;
using UnityEngine;
using Zenject;

namespace Code.Logic.Initializers
{
    public class MainLevelInitializer : MonoBehaviour
    {
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }
    }
}