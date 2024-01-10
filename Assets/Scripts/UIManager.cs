using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private int health = 3;
    private int score = 0;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private TMP_Text gameOverScoreText;
    [SerializeField] private Button playAgainButton;

    void Awake()
    {
        gameOverPanel.SetActive(false);
        playAgainButton.onClick.AddListener(playAgainAction);
        scoreText.text = "Puan: " + score;
        healthText.text = "Can: " + health;
    }

    public int addScore()
    {
        if (score < 300) score += 100;
        scoreText.text = "Puan: " + score;
        return score;
    }

    public int reduceHealth()
    {
        if (health < 300) health--;
        healthText.text = "Can: " + health;
        return health;
    }

    public void gameOverAction()
    {
        gameOverScoreText.text = "Puan: " + score;
        gameOverPanel.SetActive(true);
        Time.timeScale = 0.0f;
    }

    private void playAgainAction()
    {
        Time.timeScale = 1.0f;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("GameScene");
    }
}
