using UnityEngine.UI;
using UnityEngine;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public Text gameOverText;
    public Text continueText;

    private int score;

    private void Start()
    {
        score = 0;
        gameOverText.enabled = false;
        continueText.enabled = false;
        UpdateScore();
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
        continueText.enabled = true;
        gameOverText.text = "Game Over!";
        continueText.text = "Press R to Continue!";
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R is press");
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    private void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }
}
