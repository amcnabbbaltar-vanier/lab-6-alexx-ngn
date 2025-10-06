using UnityEngine;
using UnityEngine.SceneManagement; // Add this namespace
using UnityEngine.UI; // Add this for UI components

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int score = 0;
    public int targetScore = 4; // Score to reach before changing scenes
    public Text scoreText; // Add this UI Text component reference

    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void Die()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(1);
            GameManager.Instance.LoadNextScene();
        }
    }
}
