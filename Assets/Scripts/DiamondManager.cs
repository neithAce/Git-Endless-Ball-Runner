using TMPro;
using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    public static DiamondManager instance;

    public TextMeshProUGUI TxtDiamond;

    private int totalDiamond;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        totalDiamond = PlayerPrefs.GetInt("Diamond", 0);
        TxtDiamond.text = "Diamond " + totalDiamond;
    }

    public void AddDiamond(int amount)
    {
        totalDiamond += amount;
        PlayerPrefs.SetInt("Diamond", totalDiamond);
        PlayerPrefs.Save();
        TxtDiamond.text = "Diamond " + totalDiamond;
    }

    public int GetDiamond()
    {
        return totalDiamond;
    }

    private void UpdateDiamondText()
    {
        TxtDiamond.text = "Diamond " + totalDiamond;
    }

    public void SpendDiamond(int amount)
    {
        totalDiamond -= amount;
        if (totalDiamond < 0)
        {
            totalDiamond = 0;
        }
        PlayerPrefs.SetInt("Diamond", totalDiamond);
        PlayerPrefs.Save();
        TxtDiamond.text = "Diamond " + totalDiamond;
    }
}
