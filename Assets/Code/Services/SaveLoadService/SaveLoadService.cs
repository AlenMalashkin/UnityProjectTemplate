using Code.Data.Models.ProgressModels;
using Code.Data.Progress;
using Code.Extensions;
using UnityEngine;

namespace Code.Services.SaveLoadService
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string Key = "Progress";
        
        private readonly IPlayerProgressModel _progress;
        
        public SaveLoadService(IPlayerProgressModel progress)
        {
            _progress = progress;
        }

        public PlayerProgress Load()
            => PlayerPrefs.GetString(Key).FromJson<PlayerProgress>();

        public void Save()
            => PlayerPrefs.SetString(Key, _progress.Progress.ToJson());
    }
}