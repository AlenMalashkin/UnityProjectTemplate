using Code.Providers.MenuProvider;
using Code.UI.Factories;
using Code.UI.Windows;
using Code.UI.Windows.Menu;
using UnityEngine;
using Zenject;

namespace Code.Logic.Initializers
{
    public class MenuInitializer : MonoBehaviour
    {
        private IUIFactory _uiFactory;
        private IMenuEntitiesProvider _menuProvider;

        [Inject]
        private void Construct(IUIFactory uiFactory, IMenuEntitiesProvider menuProvider)
        {
            _uiFactory = uiFactory;
            _menuProvider = menuProvider;
        }

        private void Awake()
        {
            _menuProvider.MenuWindow = _uiFactory.CreateWindow(WindowType.Menu) as MenuWindow;
        }
    }
}