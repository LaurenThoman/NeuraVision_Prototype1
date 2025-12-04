using System.Collections.Generic;
using UnityEngine;

public class UIPageManager : MonoBehaviour
{
    [SerializeField] private GameObject[] pages;
    [SerializeField] private int startingIndex = 0;

    private Stack<int> history = new Stack<int>();
    private int currentIndex = 0;

    private void Awake()
    {
        // Make sure all pages start off
        if (pages == null) return;

        for (int i = 0; i < pages.Length; i++)
        {
            if (pages[i] != null)
                pages[i].SetActive(false);
        }
    }

    private void Start()
    {
        // Decide which page should show first
        currentIndex = startingIndex;

        if (pages != null &&
            currentIndex >= 0 &&
            currentIndex < pages.Length &&
            pages[currentIndex] != null)
        {
            pages[currentIndex].SetActive(true);
        }
    }

    public void GoToPage(int index)
    {
        if (pages == null) return;
        if (index < 0 || index >= pages.Length) return;
        if (index == currentIndex) return;

        if (pages[currentIndex] != null)
            pages[currentIndex].SetActive(false);

        history.Push(currentIndex);
        currentIndex = index;

        if (pages[currentIndex] != null)
            pages[currentIndex].SetActive(true);
    }

    public void GoBack()
    {
        if (pages == null) return;
        if (history.Count == 0) return;

        if (pages[currentIndex] != null)
            pages[currentIndex].SetActive(false);

        currentIndex = history.Pop();

        if (pages[currentIndex] != null)
            pages[currentIndex].SetActive(true);
    }
}
