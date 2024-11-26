using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public int score;
    public TextMeshProUGUI scoreDisplay;

    [Header("Game Over")]
    public TextMeshProUGUI gameOverText;
    public bool isGameActive = true;

    [Header("Restart")]
    public Button restartButton;

    [Header("Lives")]
    public int maxLives;
    public int lives;
    public TextMeshProUGUI livesDisplay;

    // Start is called before the first frame update
    void Start()
    {
        lives = maxLives;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore()
    {
        scoreDisplay.text = "Score: " + score;
    }

    public void AddScore(int amountToAdd)
    {
        score += amountToAdd;
        UpdateScore();
    }

    public void UpdateLives()
    {
        livesDisplay.text = $"Lives: {lives}";
    }

    public void LoseLife()
    {
        lives--;
        UpdateLives();
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
