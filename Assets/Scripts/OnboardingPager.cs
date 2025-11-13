using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class OnboardingPager : MonoBehaviour
{
    [SerializeField] Transform contentPagesParent;

    [Header("Buttons")]
    [SerializeField] Button backButton;
    [SerializeField] Button continueButton;
    [SerializeField] TMP_Text continueLabel;
    [SerializeField] string nextSceneName = "AccountScene";
    [SerializeField] string lastPageText = "Get Started";

    int index;
    GameObject[] pages;

    void Awake()
    {
        int n = contentPagesParent.childCount;
        pages = new GameObject[n];
        for (int i = 0; i < n; i++) pages[i] = contentPagesParent.GetChild(i).gameObject;
        ShowPage(0);
    }

    public void BackPage()
    {
        if (index > 0) ShowPage(index - 1);
    }

    public void NextPage()
    {
        if (index < pages.Length - 1) ShowPage(index + 1);
        else SceneManager.LoadScene(nextSceneName);
    }

    void ShowPage(int target)
    {
        index = Mathf.Clamp(target, 0, pages.Length - 1);
        for (int i = 0; i < pages.Length; i++) pages[i].SetActive(i == index);

        bool first = index == 0;
        bool last = index == pages.Length - 1;

        if (backButton != null) backButton.interactable = !first;
        if (continueLabel != null) continueLabel.text = last ? lastPageText : "Continue";
    }
}
