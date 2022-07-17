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
    private bool stabilizing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    IEnumerator Stabilize()
    {
        if (stabilizing) yield break;
        stabilizing = true;

        Vector3 oldForward = transform.forward;
        Vector3 upTarget = new Vector3(transform.up.x, 1, transform.up.z);

        Vector3 tempup = transform.up;

        Quaternion from = transform.rotation;
        transform.up = upTarget;
        transform.forward = oldForward;
        Quaternion to = transform.rotation;

        transform.up = tempup;

        float t = 0;
        float targetFrames = 5f;
        while (t < targetFrames) {
            transform.rotation = Quaternion.Lerp(from, to, t/targetFrames);
            t += 1;
            yield return null;
        }
        transform.up = upTarget;
        transform.forward = oldForward;
        stabilizing = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up* wingPower);
            rb.AddForce(transform.forward * moveSpeed);

            StartCoroutine(Stabilize());
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
        if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //transform.Rotate(-transform.up, turnSpeed);
            transform.Rotate(-Vector3.up, turnSpeed);
            //rb.AddRelativeTorque(-transform.up * turnSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //transform.Rotate(transform.up, turnSpeed);
            transform.Rotate(Vector3.up, turnSpeed);
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
        /*
        Vector3 forward = transform.forward;
        transform.up = new Vector3(transform.up.x,1, transform.up.z);
        transform.forward = forward;*/
        StartCoroutine(Stabilize());
        walking = true;
    }
    private void StopWalking()
    {
        walking = false;
    }

    private void CatchBug(GameObject bug)
    {
        gameObject.GetComponent<Inventory>().AddBug(bug.GetComponent<Bug>());
        bug.SetActive(false);
        print("Caught bug");
    }
}
