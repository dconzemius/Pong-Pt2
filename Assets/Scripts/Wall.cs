using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public Wall top;
    public Wall bottom;
    public Ball ball;
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
        
        Rigidbody rb = GetComponent<Rigidbody>();
        Quaternion rotation = Quaternion.Euler(45f, 0f, 45f);
        Vector3 bounceDirection = rotation * Vector3.Reflect(collision.relativeVelocity, Vector3.forward);
        rb.AddForce(bounceDirection * 100f, ForceMode.Force);


    }
}
