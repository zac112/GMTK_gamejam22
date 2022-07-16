using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotater : MonoBehaviour
{
    public float speed = 1;

    void Update()
    {
        transform.Rotate(transform.up, Time.deltaTime*speed);
    }
}
