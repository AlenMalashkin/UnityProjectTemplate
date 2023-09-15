using Code.UI.Elements.Root;
using Code.UI.Windows;

namespace Code.UI.Factories
{
    public interface IUIFactory
    {
        UIRoot CreateUIRoot();
        WindowBase CreateWindow(WindowType type);
    }
}