using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;

    public static int globalScore = 0;
    private int _levelScore = 0;

    private void OnEnable()
    {
        score.text = globalScore.ToString();
    }

    public void increaseLevelScore()
    {
        _levelScore += 10;
        globalScore += 10;
        displayScoreOnUI();
    }

    public void decreaseLevelScore()
    {
        _levelScore -= 10;
        if (_levelScore >= 0)
            globalScore -= 10;
        displayScoreOnUI();
        
    }

    private void displayScoreOnUI()
    {
        score.text = globalScore.ToString();
    }

   
}
