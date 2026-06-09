using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int diamondValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DiamondManager.instance.AddDiamond(diamondValue);
            Destroy(gameObject);
        }
    }
}
