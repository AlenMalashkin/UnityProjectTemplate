using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.Constants;
using Code.StaticData.WindowsStaticData;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private Dictionary<WindowType, WindowStaticData> _windowsMap = new Dictionary<WindowType, WindowStaticData>();
        
        public void Load()
        {
            _windowsMap = Resources.LoadAll<WindowStaticData>(StaticDataPaths.WindowStaticDataPath)
                .ToDictionary(x => x.Type);
        }

        public WindowStaticData ForWindow(WindowType type)
            => _windowsMap[type];
    }
}