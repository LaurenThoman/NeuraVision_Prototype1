using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderFade : MonoBehaviour
{
    [SerializeField] string nextSceneName = "OnboardingScene";
    [SerializeField] float delay = 2f;
    [SerializeField] float fadeTime = 0.8f;
    [SerializeField] CanvasGroup cg;

    void Start() { StartCoroutine(Run()); }

    System.Collections.IEnumerator Run()
    {
        yield return new WaitForSeconds(delay);
        float t = 0f;
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            if (cg != null) cg.alpha = 1f - Mathf.Clamp01(t / fadeTime);
            yield return null;
        }
        SceneManager.LoadScene(nextSceneName);
    }
}
