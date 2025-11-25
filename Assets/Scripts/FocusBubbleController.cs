using UnityEngine;

public class FocusBubbleController : MonoBehaviour
{
    [Range(0f, 1f)]
    public float dimAmount = 0.5f;

    public Material dimMaterial;

    void Update()
    {
        if (dimMaterial == null) return;

        Color c = dimMaterial.color;
        c.a = dimAmount;
        dimMaterial.color = c;
    }

    public void SetDimFromSlider(float value)
    {
        dimAmount = value;
    }
}
