using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; //singleton for global access

    public TextMeshProUGUI TxtScore;

    private int totalScore;

    public int distanceMultiplier = 1;

    private Transform player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        totalScore = Mathf.FloorToInt(player.position.z * distanceMultiplier);
        TxtScore.text = totalScore.ToString();
    }

    public int GetScore()
    {
        return totalScore;
    }
}
