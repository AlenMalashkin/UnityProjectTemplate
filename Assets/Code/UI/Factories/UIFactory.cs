using Code.Infrastructure.Constants;
using Code.Services.StaticDataService;
using Code.StaticData.WindowsStaticData;
using Code.UI.Elements.Root;
using Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace Code.UI.Factories
{
    public class UIFactory : IUIFactory
    {
        private readonly DiContainer _diContainer;
        private IStaticDataService _staticDataService;
        
        private Transform _uiRoot;
        
        public UIFactory(DiContainer diContainer, IStaticDataService staticDataService)
        {
            _diContainer = diContainer;
            _staticDataService = staticDataService;
        }
        
        public UIRoot CreateUIRoot()
        {
            UIRoot uiRoot = _diContainer.InstantiatePrefabResourceForComponent<UIRoot>(UIResourcesPaths.UIRoot);
            _uiRoot = uiRoot.transform;
            return uiRoot;
        }

        public WindowBase CreateWindow(WindowType type)
        {
            WindowStaticData windowStaticData = _staticDataService.ForWindow(type);
            
            WindowBase window = _diContainer
                .InstantiatePrefabForComponent<WindowBase>(windowStaticData.Template);
            window.Initialize();
            return window;
        }
    }
}