using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestApproacher : MonoBehaviour
{
    public Transform nestView;
    public GameObject nest;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(ApproachNest(other.gameObject.transform.parent.gameObject));
        }
    }

    IEnumerator ApproachNest(GameObject player)
    {
        float t = 0;
        float targetT = 1;
        Vector3 start = player.transform.position;
        Quaternion startRot = player.transform.rotation;
        while(t < targetT)
        {
            player.transform.position = Vector3.Lerp(start, nestView.position, t / targetT);
            player.transform.rotation = Quaternion.Lerp(startRot, nestView.rotation,t/targetT);
            t += Time.deltaTime;
            yield return null;
        }
        nest.GetComponent<NestGUI>().Activate();
        while (!Input.GetKeyDown(KeyCode.Return))
        {
            player.transform.position = nestView.position;
            player.transform.rotation = nestView.rotation;
            yield return null;
        }
        nest.GetComponent<NestGUI>().Deactivate();
        /*
        t = 0;
        while (t < targetT)
        {
            t += Time.deltaTime;
            yield return null;
        }*/
    }
}
