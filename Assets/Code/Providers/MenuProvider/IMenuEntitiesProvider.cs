using Code.UI.Windows.Menu;

namespace Code.Providers.MenuProvider
{
    public interface IMenuEntitiesProvider
    {
        MenuWindow MenuWindow { get; set; }
    }
}