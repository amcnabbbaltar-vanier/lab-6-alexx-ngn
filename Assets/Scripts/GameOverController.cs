using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;  // Make sure to include the TextMeshPro namespace

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;

    public void Start()
    {
        // Find the game over panel if not assigned
        if (gameOverPanel == null)
        {
            gameOverPanel = GameObject.Find("GameOverPanel");
        }
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        
        if (GameManager.Instance)
        {
            scoreText.text = "Score: " + GameManager.Instance.score.ToString();
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
