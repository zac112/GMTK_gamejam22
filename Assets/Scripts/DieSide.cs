using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSide : MonoBehaviour
{
    public int side;

    private void OnTriggerEnter(Collider collision)
    {
        GameManager.babiesTotal = 7 - side;
        print(GameManager.babiesTotal);
        
    }
}
