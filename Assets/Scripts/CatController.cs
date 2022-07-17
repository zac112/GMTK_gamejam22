using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
    GameObject player;
    GameObject waypoint;
    public float speed = 1;

    void Start()
    {
        waypoint = new GameObject("Cat WP");
        StartCoroutine(TrackPlayer());
    }

    IEnumerator TrackPlayer()
    {
        yield return GetPlayer();
        yield return GetNewWaypoint();

        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, speed);
            if (Vector3.Distance(transform.position, waypoint.transform.position) < 1)
            {
                yield return GetNewWaypoint();
            }
            yield return null;
        }
    }

    IEnumerator GetNewWaypoint()
    {
        float dist = 25;
        Vector3 newPos;
        do
        {
            newPos = new Vector3(
                    Random.Range(-dist, dist),
                    -player.transform.position.y,
                    Random.Range(-dist, dist))
            + player.transform.position;
        }
        while (Vector3.Distance(newPos, transform.position) < 3);
        waypoint.transform.position = newPos;
        yield return TurnTowardsWaypoint();
    }

    private IEnumerator TurnTowardsWaypoint()
    {
        float frame = 0;
        int frames = 5;
        Quaternion rot = Quaternion.FromToRotation(transform.forward, waypoint.transform.position - transform.forward);
        while (frame < frames)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, rot, frame / frames);
            frame++;
            yield return null;
        }
        transform.LookAt(waypoint.transform);
    }

    IEnumerator GetPlayer()
    {
        while (!player)
        {
            yield return new WaitForSeconds(2);
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            SceneManager.LoadScene("LoseScene");
        }
    }
}
