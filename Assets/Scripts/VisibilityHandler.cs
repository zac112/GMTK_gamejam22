using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibilityHandler : MonoBehaviour
{
    public GameObject TreeLod0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            other.gameObject.GetComponent<TreeLODControl>().ShowGoodDetail();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            other.gameObject.GetComponent<TreeLODControl>().ShowLowDetail();
        }
    }
}
