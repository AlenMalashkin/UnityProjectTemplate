using System;
using System.Collections;
using Code.Infrastructure.Bootstrap;
using Code.UI.LoadingCurtain;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Services.SceneLoadService
{
    public class SceneLoadService : ISceneLoadService
    {
        private ICoroutineRunner _coroutineRunner;
        
        public SceneLoadService(ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
        }

        public void Load(string sceneName, Action onLoad = null)
        {
            _coroutineRunner.StartCoroutine(LoadScene(sceneName, onLoad));
        }

        private IEnumerator LoadScene(string sceneName, Action onLoad = null)
        {
            AsyncOperation asyncSceneLoading = SceneManager.LoadSceneAsync(sceneName);

            while (asyncSceneLoading.isDone)
                yield return null;
            
            onLoad?.Invoke();
        }
    }
}