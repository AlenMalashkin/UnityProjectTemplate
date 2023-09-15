using Code.StaticData.WindowsStaticData;
using Code.UI.Windows;

namespace Code.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Load();
        WindowStaticData ForWindow(WindowType type);
    }
}