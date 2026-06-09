using UnityEngine;

public class DiamondFloat : MonoBehaviour
{
    public float floatHeight = 0.5f;
    public float floatSpeed = 2f;

    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        transform.position = startPosition + Vector3.up * Mathf.Sin(Time.time * floatSpeed) * floatHeight;
    }
}
