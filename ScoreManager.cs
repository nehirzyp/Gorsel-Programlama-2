using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameOverScreen;
    PickupManager pickups;
    int totalPickups;
    int currentScore = 0;

    private void Start()
    {
        pickups = FindObjectOfType<PickupManager>();    
        totalPickups = pickups.amount;
        UpdateScoreText();
    }

    public void CollectPickup()
    {
        currentScore++;
        UpdateScoreText();

        if (currentScore >= totalPickups)
        {
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f; // Pause the game
        }
    }

    public void UpdateScoreText()
    {
       scoreText.text = "Score: " + currentScore + " / " + totalPickups;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
