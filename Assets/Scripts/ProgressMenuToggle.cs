using UnityEngine;

public class ProgressMenuToggle : MonoBehaviour
{
    public GameObject progressPanel;

    bool isVisible = true;

    void Start()
    {
        if (progressPanel != null)
        {
            isVisible = progressPanel.activeSelf;
        }
    }

    public void ToggleProgressMenu()
    {
        if (progressPanel == null) return;

        isVisible = !isVisible;
        progressPanel.SetActive(isVisible);
    }
}
