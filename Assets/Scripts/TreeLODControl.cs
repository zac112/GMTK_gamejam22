using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLODControl : MonoBehaviour
{
    public MeshRenderer goodDetail;
    public MeshRenderer lowDetail;

    public void ShowGoodDetail()
    {
        lowDetail.enabled = false;
        goodDetail.enabled = true;
    }

    public void ShowLowDetail()
    {
        lowDetail.enabled = true;
        goodDetail.enabled = false;
    }
}
