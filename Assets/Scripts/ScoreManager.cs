using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance; //singleton for global access

    public TextMeshProUGUI TxtScore;
    public TextMeshProUGUI TxtBestScore;

    private int totalScore;
    private int bestScore;

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
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        TxtBestScore.text = "BEST: " + bestScore;
    }

    private void Update()
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        totalScore = Mathf.FloorToInt(player.position.z * distanceMultiplier);
        if(totalScore > bestScore)
        {
            bestScore = totalScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        TxtScore.text = totalScore.ToString();
        TxtBestScore.text = "BEST: " + bestScore;
    }

    public int GetScore()
    {
        return totalScore;
    }
}
