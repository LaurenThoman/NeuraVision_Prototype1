using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoachingTabs : MonoBehaviour
{
    [Header("Pages in order")]
    [SerializeField] private GameObject[] pages;

    [Header("Buttons in same order")]
    [SerializeField] private Button[] buttons;

    [Header("Startup page index")]
    [SerializeField] private int startPageIndex = 0;

    private int currentIndex = -1;
    private Stack<int> history = new Stack<int>();

    private void Awake()
    {
        // Wire the tab buttons
        for (int i = 0; i < buttons.Length; i++)
        {
            int captured = i;
            buttons[i].onClick.AddListener(() => ShowPage(captured, true));
        }

        // First page, do not add to history
        ShowPage(startPageIndex, false);
    }

    // Called by tab buttons and by code
    public void ShowPage(int index)
    {
        ShowPage(index, true);
    }

    private void ShowPage(int index, bool addToHistory)
    {
        if (pages == null || pages.Length == 0) return;

        index = Mathf.Clamp(index, 0, pages.Length - 1);
        if (index == currentIndex) return;

        if (addToHistory && currentIndex >= 0)
        {
            history.Push(currentIndex);
        }

        currentIndex = index;

        for (int i = 0; i < pages.Length; i++)
        {
            bool active = (i == currentIndex);
            if (pages[i] != null)
                pages[i].SetActive(active);
        }
    }

    public void GoBack()
    {
        if (history.Count == 0) return;

        int previous = history.Pop();
        ShowPage(previous, false);
    }
}
