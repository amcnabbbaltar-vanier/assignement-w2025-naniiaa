using System;
using UnityEngine;

using UnityEngine.SceneManagement;

/**
 * I am using one script to control the health, timer, and score so that it is easier to manage instead of using multiple scripts.
 * 
 * For other things, like, pickups and powerups, I will separate them.
 */
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }


    public int playerHealth = 0;
    public int score = 0;
    public float gameTime = 0f;
    public int currentLevel = 0;
    public Boolean isGamePaused = false;

    public string MainMenuScene = "MainMenuScene";
    public string[] LevelScenes = {"TutorialScene", "Level-1", "Level-2", "Level-3" };
    public string EndScreenScene = "GameOverScreen";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeGame();
            Debug.Log("Initializing Game Manager . . .");
        }
        else
        {
            Debug.Log("Duplicate GameManager . . . Being destroyed.");
            Destroy(gameObject);

        }
    }

    private void InitializeGame()
    {
        playerHealth = 3;
        score = 0;
        gameTime = 0f;
        currentLevel = 0;
        isGamePaused = false;
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name != MainMenuScene && SceneManager.GetActiveScene().name != EndScreenScene && playerHealth == 0) 
        {
            InitializeGame(); 
        }

        if (!isGamePaused && SceneManager.GetActiveScene().name != MainMenuScene && SceneManager.GetActiveScene().name != EndScreenScene)
        {
            gameTime += Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        UIManager uiManager = FindFirstObjectByType<UIManager>();
        if (uiManager != null)
        {
            uiManager.UpdateHealthUI(playerHealth);
        }

        if (playerHealth <= 0)
        {
            RestartLevel();
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UIManager uiManager = FindFirstObjectByType<UIManager>();
        if (uiManager != null)
        {
            uiManager.UpdateScoreUI(score);
        }

    }

    public void ResetHealth()
    {
        playerHealth = 3;
    }
    public void ResetScore()
    {
        score = 0;
    }


    public void LoadNextLevel()
    {
        currentLevel++;

        int currentScore = score;

        if (currentLevel < LevelScenes.Length)
        {
            SceneManager.LoadScene(LevelScenes[currentLevel]);
        }
        else
        {
            SceneManager.LoadScene(EndScreenScene);
        }
    }

    public void RestartLevel()
    {
        ResetHealth();
        // ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void RestartGame()
    {
        InitializeGame();
        SceneManager.LoadScene(LevelScenes[0]);
    }

    public void QuitToMainMenu()
    {
        InitializeGame();
        SceneManager.LoadScene(MainMenuScene);
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60f);
        int seconds = Mathf.FloorToInt(gameTime % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}