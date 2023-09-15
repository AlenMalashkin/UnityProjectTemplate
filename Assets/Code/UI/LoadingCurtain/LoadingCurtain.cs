using System.Collections;
using UnityEngine;

namespace Code.UI.LoadingCurtain
{
    public class LoadingCurtain : MonoBehaviour, ILoadingCurtain
    {
        [SerializeField] private CanvasGroup curtainCanvasGroup;
        
        public void Show()
        {
            gameObject.SetActive(true);
            curtainCanvasGroup.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(DoFadeOut());
            if (curtainCanvasGroup.alpha < 0.03f)
                gameObject.SetActive(false);
        }

        private IEnumerator DoFadeOut()
        {
            while (curtainCanvasGroup.alpha > 0)
            {
                curtainCanvasGroup.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}