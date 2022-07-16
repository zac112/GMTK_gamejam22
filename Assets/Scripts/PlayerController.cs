using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float wingPower = 1f;
    public float moveSpeed = 1f;
    public float turnSpeed = 1f;
    public float walkSpeed = 0.1f;
    public bool walking = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up* wingPower);
            rb.AddForce(transform.forward * moveSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-Vector3.right, turnSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.right, turnSpeed);
            //rb.AddTorque(transform.right * turnSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-transform.up, turnSpeed);
            //transform.Rotate(-Vector3.up, turnSpeed);
            //rb.AddRelativeTorque(-transform.up * turnSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(transform.up, turnSpeed);
            //transform.Rotate(Vector3.up, turnSpeed);
            //rb.AddRelativeTorque(transform.up*turnSpeed);
            //rb.AddTorque(-transform.right * turnSpeed);
        }
        if (IsWalking())
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += transform.forward * walkSpeed;
            }
        }
    }

    private bool IsWalking()
    {
        return walking;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bug")) CatchBug(collision.gameObject);
        if (collision.gameObject.CompareTag("Terrain")) StartWalking();
        if (collision.gameObject.CompareTag("Tree")) StartWalking();

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Terrain")) StopWalking();
        if (collision.gameObject.CompareTag("Tree")) StopWalking();

    }
    private void StartWalking()
    {
        transform.up = Vector3.up;
        walking = true;
    }
    private void StopWalking()
    {
        walking = false;
    }

    private void CatchBug(GameObject bug)
    {
        print("Caught bug");
    }
}
