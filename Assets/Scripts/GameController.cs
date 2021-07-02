using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int score = 0;

    public static GameController controller;

    public Text txtScore;

    void Start()
    {
        controller = this;
    }


    public void updateScore()
    {
        txtScore.text = score.ToString();
    }
}
