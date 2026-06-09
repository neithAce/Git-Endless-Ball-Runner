using System.Collections;
using TMPro;
using UnityEngine;

public enum GameState
{
    MainMenu,
    Playing,
    Pause,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    public static bool startFromMenu = true;

    public GameObject mainMenuUI;
    public GameObject inGameMenuUI;
    public GameObject PauseMenuUI;
    public GameObject GameOverUI;
    public TextMeshProUGUI txtScoreGameOver;

    public GameState currentState { get; private set; }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (RestartGame.restartGame)
        {
            RestartGame.restartGame = false;
            currentState = GameState.Playing;
            HandleStateChange();
        }
        else
        {
            currentState = GameState.MainMenu;
            HandleStateChange();
        }
    }

    public void ChangeState(GameState newState)
    {
        //if (currentState == newState) return;

        StartCoroutine(TransitionToState(newState));

        currentState = newState;
    }

    public void ChangeToMainMenu()
    {
        ChangeState(GameState.MainMenu);
    }

    public void ChangeToPlaying()
    {
        ChangeState(GameState.Playing);
    }

    public void ChangeToPause()
    {
        ChangeState(GameState.Pause);
    }

    public void ChangeToGameOver()
    {
        ChangeState(GameState.GameOver);
    }

    private IEnumerator TransitionToState(GameState newState)
    {
        if(newState != GameState.MainMenu)
        {
            yield return new WaitForSecondsRealtime(1);
        }

        currentState = newState;
        HandleStateChange();
    }

    private void HandleStateChange()
    {
        HideAllMenu();

        switch (currentState)
        {
            case GameState.MainMenu:
                Time.timeScale = 0;
                mainMenuUI.SetActive(true);
                AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
                break;
            case GameState.Playing:
                inGameMenuUI.SetActive(true);
                Time.timeScale = 1;
                AudioManager.instance.PlayMusic(AudioManager.instance.inGameMusic);
                break;
            case GameState.Pause:
                PauseMenuUI.SetActive(true);
                Time.timeScale = 0;
                AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
                break;
            case GameState.GameOver:
                GameOverUI.SetActive(true);
                txtScoreGameOver.text = ScoreManager.instance.TxtScore.text;
                Time.timeScale = 0;
                AudioManager.instance.PlayMusic(AudioManager.instance.menuMusic);
                break;
        }
    }

    private void HideAllMenu()
    {
        mainMenuUI.SetActive(false);
        inGameMenuUI.SetActive(false);
        PauseMenuUI.SetActive(false);
        GameOverUI.SetActive(false);
    }
}
