using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugController : MonoBehaviour
{
    private SphereCollider area;
    private Transform checkpoint;
    public float speed = 1;

    void Start()
    {
        area = transform.parent.GetComponent<SphereCollider>();
        GameObject go = new GameObject("WP");
        go.transform.parent = transform.parent;
        checkpoint = go.transform;
        GetNewCheckpoint();
        StartCoroutine(Move());
    }

    private void GetNewCheckpoint()
    {
        Vector3 newPos = Random.insideUnitSphere * area.radius;
        newPos = new Vector3(newPos.x, Mathf.Clamp(newPos.y, 0, float.MaxValue), newPos.z);
        checkpoint.localPosition = newPos;
    }

    IEnumerator Move()
    {
        while (true)
        {
            yield return new WaitWhile(() => !checkpoint);
            if (Vector3.Distance(checkpoint.position, transform.position) < 2f) GetNewCheckpoint();

            Vector3 newPos = Vector3.MoveTowards(transform.position, checkpoint.position, speed);
            transform.position = newPos;
            Quaternion rot = Quaternion.FromToRotation(transform.forward, checkpoint.position - transform.forward);
            //Quaternion rot = Quaternion.FromToRotation(Vector3.zero, waypoints[i].transform.position);
            if (Quaternion.Angle(rot, transform.rotation) > 5)
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 0.5f);

            yield return null;
        }
    }
}
