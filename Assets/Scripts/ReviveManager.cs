using UnityEngine;

public class ReviveManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public void Revive()
    {
        if(CoinManager.instance.GetCoin() >= 100)
        {
            CoinManager.instance.SpendCoin(100);
            gameOverUI.SetActive(false);
            Time.timeScale = 1;
            GameStateManager.instance.ChangeToPlaying();
        }
    }
}
