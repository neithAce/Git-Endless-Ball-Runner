using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int diamondValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.diamondClip);
            DiamondManager.instance.AddDiamond(diamondValue);
            Destroy(gameObject);
        }
    }
}
