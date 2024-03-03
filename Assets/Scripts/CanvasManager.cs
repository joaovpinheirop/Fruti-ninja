using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{

    public Text score;
    public Text best;
    public Text life;


    // Update is called once per frame
    void Update()
    {
        PrintLife(GameManager.Instance.life.ToString());
        PrintScore(GameManager.Instance.score.ToString());
        PrintBest(GameManager.Instance.recordScore.ToString());
    }

    void PrintScore(string text)
    {
        score.text = text;
    }

    void PrintBest(string text)
    {
        best.text = "Best: " + text;
    }

    void PrintLife(string text)
    {
        life.text = "Life: " + text;
    }
}
