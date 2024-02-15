using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goals : MonoBehaviour
{
    public Ball ball;
    public float LeftPlayer = 0;
    public float RightPlayer = 0;
    public ScoreDisplay scoreDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.position.x > 0)
        {
            LeftPlayer++;
            scoreDisplay.UpdateScore();
            ball.ResetBall(-500f);
        }
        else
        {
            RightPlayer++;
            scoreDisplay.UpdateScore();
            ball.ResetBall(500f);
        }
    }
    public float getLeftScore()
    {
        return LeftPlayer;
    }
    public float getRightScore() {
        return RightPlayer; 
    }
    public void ResetCall()
    {
        ball.ResetBall(-500f);
    }
}
