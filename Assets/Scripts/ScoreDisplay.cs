using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    private int score = 0;
    private int lives = 3;
    public Text textbox;

    // Update is called once per frame
    void Update()
    {
        textbox.text = string.Format("SCORE: {0}\nLIVES: {1}", score, lives);
    }

    public void setScore(int _s)
    {
        score = _s;
    }

    public void setLives(int _l)
    {
        lives = _l;
    }
}
