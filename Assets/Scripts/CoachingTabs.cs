using UnityEngine;
using UnityEngine.UI;

public class CoachingTabs : MonoBehaviour
{
    [Header("Pages in order")]
    [SerializeField] GameObject[] pages;      // Page 1, Page 2, Page 3, Page 4

    [Header("Buttons in same order")]
    [SerializeField] Button[] buttons;        // Button for page 1, page 2, page 3, page 4

    [Header("Startup page index")]
    [SerializeField] int startPageIndex = 0;  // 0 means first page

    int currentIndex;

    void Awake()
    {
        // Wire up buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            int captured = i;
            buttons[i].onClick.AddListener(() => ShowPage(captured));
        }

        ShowPage(startPageIndex);
    }

    void ShowPage(int index)
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
