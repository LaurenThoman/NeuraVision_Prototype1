using UnityEngine;

public class FocusBubbleController : MonoBehaviour
{
    [Range(0f, 1f)]
    public float dimAmount = 0.5f;
    public Material dimMaterial;

    public bool onlyWhenBookTracked = true;

    void Update()
    {
        if (dimMaterial == null) return;

        float targetAlpha = dimAmount;

        if (onlyWhenBookTracked && BookAnchor.Current == null)
        {
            targetAlpha = 0f;
        }

        Color c = dimMaterial.color;
        c.a = targetAlpha;
        dimMaterial.color = c;
    }
}
