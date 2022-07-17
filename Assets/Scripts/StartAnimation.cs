using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public GameObject[] waypoints;
    public GameObject player;
    public GameObject bird;

    void Start()
    {
        StartCoroutine(DoAnimation());
    }

    IEnumerator DoAnimation()
    {
        TreeLODControl[] trees = GameObject.FindObjectsOfType<TreeLODControl>();
        foreach (TreeLODControl c in trees) c.ShowGoodDetail();
        Vector3 startPos = transform.position;
        float t = 0;
        float targetT = 5;
        for (int i = 0; i < waypoints.Length; i++)
        {
            //transform.LookAt(waypoints[i].transform.position);
            while (t < targetT)
            {
                transform.position = Vector3.Lerp(startPos, waypoints[i].transform.position, t / targetT);
                t += Time.deltaTime;
                Quaternion rot = Quaternion.FromToRotation(transform.forward, waypoints[i].transform.position- transform.forward);
                //Quaternion rot = Quaternion.FromToRotation(Vector3.zero, waypoints[i].transform.position);
                if(Quaternion.Angle(rot,transform.rotation) > 5)
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 0.5f);
                yield return null;
            }
            startPos = transform.position;
            t = 0;
        }
        foreach (TreeLODControl c in trees) c.ShowLowDetail();
        player.SetActive(true);
        Destroy(gameObject);
        Destroy(bird);
    }
}
