using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThankYouScreenTotScore : MonoBehaviour
{
    public Text scoreText;

    private void OnEnable()
    {
        scoreText.text = Score.globalScore.ToString();
    }

    public void Quit()
    {
        Debug.Log("Quiting the MadBird");
        Application.Quit();
    }
}
