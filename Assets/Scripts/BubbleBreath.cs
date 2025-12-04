using UnityEngine;

public class BubbleBreath : MonoBehaviour
{
    public float baseScale = 1f;
    public float amplitude = 0.1f;
    public float frequency = 1f;

    void Update()
    {
        float t = Time.time * frequency;

        // Gentle wobble in all axes
        float sx = baseScale + Mathf.Sin(t) * amplitude;
        float sy = baseScale + Mathf.Sin(t + 0.7f) * amplitude;
        float sz = baseScale + Mathf.Sin(t + 1.3f) * amplitude;

        transform.localScale = new Vector3(sx, sy, sz);
    }
}
