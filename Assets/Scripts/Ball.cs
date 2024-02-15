using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float startSpeed = 3f;
    public Transform ball;

    Vector3 ballStartPos;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Game Start!");
        ballStartPos = ball.position;
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(300f,0f,0f, ForceMode.Force);
    }

    public void ResetBall(float directionSign)
    {
       
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity = newDirection;
        rbody.angularVelocity = new Vector3();
        ball.position = ballStartPos;

        ball.GetComponent<TrailRenderer>().Clear();
    }

    public bool Powerup2(bool speedUp)
    {
        var rbody = ball.GetComponent<Rigidbody>();
        if (!speedUp)
        {
            rbody.velocity = rbody.velocity / 2;
        }
        else
        {
            rbody.velocity = rbody.velocity * 1.5f;
        }

        speedUp =!speedUp;
        return speedUp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
