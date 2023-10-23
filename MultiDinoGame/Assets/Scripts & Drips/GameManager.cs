using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text player2ScoreText;
    public TMP_Text player1ScoreText;
    private bool isPlayerDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        player1ScoreText.text = "Score";
        player2ScoreText.text = "Score";
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerDestroyed)
        {
            // Restart the game when the R key is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
                
        }
    }
    public void SetPlayerDestroyed(bool destroyed)
    {
        isPlayerDestroyed = destroyed;
    }
}
