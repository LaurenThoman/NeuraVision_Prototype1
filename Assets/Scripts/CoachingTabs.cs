using UnityEngine;
using UnityEngine.UI;

public class CoachingTabs : MonoBehaviour
{
    [Header("Pages in order")]
    [SerializeField] GameObject[] pages;

    [Header("Buttons in same order")]
    [SerializeField] Button[] buttons;

    [Header("Startup page index")]
    [SerializeField] int startPageIndex = 0;

    int currentIndex;

    void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int captured = i;
            buttons[i].onClick.AddListener(() => ShowPage(captured));
        }

        ShowPage(startPageIndex);
    }

    // make this public so other buttons can call it
    public void ShowPage(int index)
    {
        currentIndex = Mathf.Clamp(index, 0, pages.Length - 1);

        for (int i = 0; i < pages.Length; i++)
        {
            bool active = (i == currentIndex);
            if (pages[i] != null)
                pages[i].SetActive(active);
        }
    }
}
