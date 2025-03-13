using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenController : MonoBehaviour
{

    [SerializeField] public GameObject EndGamePanel;
    public TextMeshProUGUI FinalScoreText;
    public TextMeshProUGUI FinalTimeText;

    public void Start()
    {
        Cursor.visible = true;
        EndGamePanel.SetActive(true);
        DisplayFinalStats();
    }

    public void DisplayFinalStats()
    {
        if (GameManager.Instance != null)
        {
            FinalScoreText.text = " Final Score: " + GameManager.Instance.score.ToString();
            FinalTimeText.text = " Final Time: " + GameManager.Instance.GetFormattedTime();
        }
        else if(FinalScoreText != null || FinalTimeText != null)
        {
            FinalScoreText.text = " Final Score: N/A";
            FinalTimeText.text = " Time: N/A";
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1); // 1 bc level 1 is index 1

        if (GameManager.Instance != null)
        {
            GameManager.Instance.RestartGame();
        }
    }

    public void QuitToMainMenu()
    {
        SceneManager.LoadScene(0); // 0 bc main menu is index 0

        if (GameManager.Instance != null)
        {
            GameManager.Instance.QuitToMainMenu();
        }
    }


}
