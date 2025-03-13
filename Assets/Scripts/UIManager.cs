using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject[] healthIcons;

    void Start()
    {
        UpdateAllUI();
    }

    void Update()
    {
        UpdateTimer();
    }

    void UpdateAllUI()
    {
        UpdateScore();
        UpdateHealth();
        UpdateTimer();
    }

    void UpdateScore()
    {
        if (scoreText != null && GameManager.Instance != null)
        {
            scoreText.text = "Score: " + GameManager.Instance.score;
        }
    }

    void UpdateHealth()
    {
        if (healthIcons != null && GameManager.Instance != null)
        {
            int health = GameManager.Instance.playerHealth;

            for (int i = 0; i < healthIcons.Length; i++)
            {
                healthIcons[i].SetActive(i < health);
            }
        }
    }

    void UpdateTimer()
    {
        if (timerText != null && GameManager.Instance != null)
        {
            float time = GameManager.Instance.gameTime;

            int minutes = Mathf.FloorToInt(time / 60f);

            int seconds = Mathf.FloorToInt(time % 60f);

            timerText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    public void UpdateScoreUI(int newScore)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + newScore;
        }
    }

    // GM calls when health changes
    public void UpdateHealthUI(int newHealth)
    {
        if (healthIcons != null)
        {
            for (int i = 0; i < healthIcons.Length; i++)
            {
                healthIcons[i].SetActive(i < newHealth); // set active to remove the hp icon from the hud
            }
        }
    }
}