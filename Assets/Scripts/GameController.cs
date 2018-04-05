using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public Text gameOverText;
    public Text continueText;
    public Text scoreHeading;
    public Text scoreValue;
    public Image background;

    private int score;
    private bool gameOver = false;

    private void Start()
    {
        score = 0;
        gameOverText.enabled = false;
        continueText.enabled = false;
        scoreHeading.enabled = false;
        scoreValue.enabled = false;
        background.enabled = false;
        UpdateScore();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && gameOver)
        {
            SceneManager.LoadScene(0);
            Debug.Log("R is press");
        }
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
        continueText.enabled = true;
        scoreHeading.enabled = true;
        scoreValue.enabled = true;
        background.enabled = true;
        gameOverText.text = "Game Over!";
        continueText.text = "Press R to Restart!";
        scoreValue.text = score.ToString();
        gameOver = true;
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
