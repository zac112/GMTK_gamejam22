using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diceroll : MonoBehaviour
{
    public float explosionForce = 1000;
    public GameObject explosionPlace;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.AddExplosionForce(explosionForce, explosionPlace.transform.position, 10f);
            rb.AddTorque(Random.onUnitSphere);            
        }
    }

}
