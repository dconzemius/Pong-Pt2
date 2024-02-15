using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public Goals leftGoal;
    public Goals rightGoal;
    public TMPro.TextMeshProUGUI scoreText;
    private Color32 randColor;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: 0 - 0";
    }

    
    public void UpdateScore()
    {
        randColor = new Color32((byte)(Random.Range(0, 255)), (byte)(Random.Range(0, 255)), (byte)(Random.Range(0, 255)), (byte)(Random.Range(0, 255)));
            // Randomizing the color everytime UpdateScore occurs
        scoreText.color = randColor;
        if (leftGoal.getLeftScore() > 4)
        {
            
            scoreText.text = "Left Player Wins!";
            leftGoal.LeftPlayer = 0;
            rightGoal.RightPlayer = 0;
            leftGoal.ResetCall();
        }
        else if (rightGoal.getRightScore() > 4)
        {
            scoreText.text = "Right Player Wins!";
            leftGoal.LeftPlayer = 0;
            rightGoal.RightPlayer = 0;
            rightGoal.ResetCall();
        }
        else
        {
            scoreText.text = "Score: " + leftGoal.getLeftScore() + " - " + rightGoal.getRightScore();
        }
    }
}
