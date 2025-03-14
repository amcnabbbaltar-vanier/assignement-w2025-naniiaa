using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PauseMenuController : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenuPanel;
    [SerializeField] public GameObject uIManagerPanel;
    [SerializeField] public GameObject tutorialPanel;



    private bool isPaused = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        if (pauseMenuPanel != null)
            pauseMenuPanel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if(isPaused)
        {
            uIManagerPanel.SetActive(false);
            tutorialPanel.SetActive(false);
            pauseMenuPanel.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            uIManagerPanel.SetActive(true);
            tutorialPanel.SetActive(true);
            pauseMenuPanel.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void ResumeGame()
    {
        TogglePause();
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;

        isPaused = false;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.RestartLevel();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public void ReturnToMainMenu()
    {

        Time.timeScale = 1f;

        isPaused = false;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.QuitToMainMenu();
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }

}
