using UnityEngine;
using UnityEngine.SceneManagement;

public class OnboardingUI : MonoBehaviour
{
    [SerializeField] string nextSceneName = "AccountScene";
    [SerializeField] CanvasGroup cg;
    [SerializeField] float fadeTime = 0.5f;
    bool loading;

    public void OnContinue()
    {
        if (!loading) StartCoroutine(FadeAndLoad());
    }

    public void OnSkip()
    {
        if (!loading) StartCoroutine(FadeAndLoad());
    }

    System.Collections.IEnumerator FadeAndLoad()
    {
        loading = true;
        if (cg != null)
        {
            float t = 0f;
            while (t < fadeTime)
            {
                t += Time.deltaTime;
                cg.alpha = 1f - Mathf.Clamp01(t / fadeTime);
                yield return null;
            }
        }
        SceneManager.LoadScene(nextSceneName);
    }
}
