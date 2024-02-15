using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float unitsPerSecond =  0.3f;
    public Paddle RightPaddle;
    public Paddle LeftPaddle;
    public Ball ball;
    public float collisionBallSpeedUp = 1.5f;
    public AudioClip bounceSound;
    private AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        //Right paddle
        float verticalValue = Input.GetAxis("Vertical");
        Vector3 force = Vector3.forward * verticalValue * unitsPerSecond;
        Rigidbody rb = RightPaddle.GetComponent<Rigidbody>();
        rb.AddForce(force, ForceMode.Force);
        
        //Left paddle
        float vertical2Value = Input.GetAxis("Vertical2");
        Rigidbody rb2 = LeftPaddle.GetComponent<Rigidbody>();
        Vector3 force2 = Vector3.forward * vertical2Value * unitsPerSecond;
        rb2.AddForce(force2, ForceMode.Force);        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ball")
        {
        BoxCollider bc = GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float minZ = bounds.max.z;
        float maxZ = bounds.min.z;
        float percent = (collision.transform.position.z - minZ) / (maxZ - minZ);

        float bounceDirection = (percent - 0.5f) / 0.5f;
        Vector3 currentVelocity = collision.relativeVelocity;
        float newSign = -Math.Sign(currentVelocity.x);
        float newRotSign = newSign;

        float newSpeed = currentVelocity.magnitude * collisionBallSpeedUp;
        Vector3 newVelocity = new Vector3(newSign, 0f, 0f) * newSpeed;
        newVelocity = Quaternion.Euler(0f, newRotSign * 60f * bounceDirection, 0f) * newVelocity;
        collision.rigidbody.velocity = newVelocity;
        
           
            
            source.PlayOneShot(bounceSound,collision.relativeVelocity.magnitude);
        }
        
    }

    public bool Powerup1(bool size)
    {
        if (size)
        {
            LeftPaddle.transform.localScale = new Vector3(1f, 1f, 4f);
            RightPaddle.transform.localScale = new Vector3(1f, 1f, 4f);
        }
        else
        {
            LeftPaddle.transform.localScale = new Vector3(0.5f, 0.5f, 2f);
            RightPaddle.transform.localScale = new Vector3(0.5f, 0.5f, 2f);
        }
        size = !size;
        return size;
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
