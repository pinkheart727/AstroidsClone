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


    // Start is called before the first frame update
    void Start()
    {

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

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
