using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject flyer;
    public GameObject crawler;
    public GameObject treeBug;
    public int numBugs;
    public Terrain terrain;
    private GameObject goParent;

    void Start()
    {
        goParent = new GameObject("Bugs");
        SpawnFlyers();
        SpawnTreeBugs();
        //SpawnCrawlerBugs();
    }

    void SpawnFlyers()
    {
        TerrainCollider c = terrain.GetComponent<TerrainCollider>();
        for (int i = 0; i < numBugs; i++)
        {

            float x = Random.Range(0, c.bounds.size.x);
            float y = Random.Range(0, 100);
            float z = Random.Range(0, c.bounds.size.z);
            GameObject go = Instantiate<GameObject>(flyer);
            go.transform.position = new Vector3(x, y, z);
            go.transform.parent = goParent.transform;
        }
    }

    void SpawnTreeBugs()
    {
        List<GameObject> spawns = new List<GameObject>(GameObject.FindGameObjectsWithTag("TreebugSpawn"));
        int spawnNum = spawns.Count / 3;
        for (int i = 0; i < spawnNum; i++)
        {
            int index = Random.Range(0, spawns.Count);
            GameObject spawn = spawns[index];
            spawns.RemoveAt(index);

            GameObject go = Instantiate<GameObject>(treeBug);
            go.GetComponent<BugTreeController>().waypoint = spawn.GetComponent<TreebugWaypoint>().nextWaypoint;
            go.transform.position = spawn.transform.position;
            go.transform.parent = goParent.transform;
        }
    }

    void SpawnCrawlerBugs()
    {
        TerrainCollider c = terrain.GetComponent<TerrainCollider>();
        for (int i = 0; i < numBugs; i++)
        {

            float x = Random.Range(0, c.bounds.size.x);
            float z = Random.Range(0, c.bounds.size.z);
            GameObject go = Instantiate<GameObject>(flyer);
            go.transform.position = new Vector3(x, 0, z);
            go.transform.parent = goParent.transform;
        }
    }
}
