using UnityEngine;

public class BookAnchor : MonoBehaviour
{
    public static Transform Current;

    void OnEnable()
    {
        Current = transform;
    }

    void OnDisable()
    {
        if (Current == transform)
        {
            Current = null;
        }
    }
}
