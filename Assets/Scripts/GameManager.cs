using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public int score;
    public TextMeshProUGUI scoreDisplay;

    //[Header("Game Over")]

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
}
