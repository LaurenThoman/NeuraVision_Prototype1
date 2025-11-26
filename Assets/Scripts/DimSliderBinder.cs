using UnityEngine;
using UnityEngine.UI;

public class DimSliderBinder : MonoBehaviour
{
    public FocusBubbleController bubble;   // reference to your DimmingBubble script
    private Slider slider;

    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (bubble == null || slider == null) return;

        // Slider value is assumed to be from 0 to 1
        bubble.dimAmount = slider.value;
    }
}
