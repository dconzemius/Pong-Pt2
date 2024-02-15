using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup1 : MonoBehaviour
    
{
    public Paddle LeftPaddle;
    public Paddle RightPaddle;
    private bool size = false;
    public Ball ball;
    private bool speedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.name == "Powerup 1") // First powerup will change the size of the paddles 
        {
            RightPaddle.Powerup1(size);
            size = LeftPaddle.Powerup1(size);
            

        } else if (this.gameObject.name == "Powerup 2") // Second powerup will either speed the ball up or slow the ball down
        {
          speedUp = ball.Powerup2(speedUp);
        }
    }
}
