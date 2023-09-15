using Code.Data.Progress;

namespace Code.Services.SaveLoadService
{
    public interface ISaveLoadService
    {
        PlayerProgress Load();
        void Save();
    }
}