using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugTreeController : MonoBehaviour
{

    public GameObject waypoint;
    public float speed = 1f;

    private void Start()
    {
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitWhile(() => !waypoint);
            transform.localPosition = Vector3.MoveTowards(transform.position, waypoint.transform.position, speed);
            if (Vector3.Distance(transform.position, waypoint.transform.position) < 1)
            {
                waypoint = waypoint.GetComponent<TreebugWaypoint>().nextWaypoint;
            }
            yield return null;
        }
    }
}
