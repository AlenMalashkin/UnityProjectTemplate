using System;
using System.Collections;

namespace Code.Services.SceneLoadService
{
    public interface ISceneLoadService
    {
        void Load(string sceneName, Action onLoad = null);
    }
}