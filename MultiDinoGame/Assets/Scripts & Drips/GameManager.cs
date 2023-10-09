using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isPlayerDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
