using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text player2ScoreText;
    public TMP_Text player1ScoreText;

    private float player1Score;
    private float player2Score;
    private bool isPlayer1Destroyed = false;
    private bool isPlayer2Destroyed = false;
    private bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        player1ScoreText.text = "Score: 0";
        player2ScoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameEnded)
        {
            if (!isPlayer1Destroyed)
            {
                player1Score += Time.deltaTime;
                UpdatePlayer1ScoreText();
            }
            if (!isPlayer2Destroyed)
            {
                player2Score += Time.deltaTime;
                UpdatePlayer2ScoreText();
            }
            if (isPlayer1Destroyed && isPlayer2Destroyed)
            {
                gameEnded = true;
            }

        }
        if (gameEnded)
        {
            // Restart the game when the R key is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

    }
    public void SetPlayer1Destroyed(bool destroyed)
    {
        isPlayer1Destroyed = destroyed;
    }
    public void SetPlayer2Destroyed(bool destroyed)
    {
        isPlayer2Destroyed = destroyed;
    }
    void UpdatePlayer1ScoreText()
    {
        player1ScoreText.text = "Player 1 Score: " + Mathf.Round(player1Score);
    }
    void UpdatePlayer2ScoreText()
    {
        player2ScoreText.text = "Player 2 Score: " + Mathf.Round(player2Score);
    }
}
