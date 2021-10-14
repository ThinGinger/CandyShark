using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public float restartDelay = 2f;

    public void gameEnd()
    {
        if(!gameEnded)
        {
            gameEnded = true;
            Debug.Log("GAME OVER");
            Invoke("gameRestart", restartDelay);
        }
    }

    void gameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
