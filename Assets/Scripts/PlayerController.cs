using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float wingPower = 1f;
    public float moveSpeed = 1f;
    public float turnSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        print(rb.velocity);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up* wingPower);
            rb.AddForce(transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddTorque(-transform.right * turnSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddTorque(transform.right * turnSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddRelativeTorque(-transform.up * turnSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Rotate(transform.up, turnSpeed);
            rb.AddRelativeTorque(transform.up*turnSpeed);
            //rb.AddTorque(-transform.right * turnSpeed);
        }
    }
}
