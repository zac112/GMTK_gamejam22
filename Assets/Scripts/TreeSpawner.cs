using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    [Serializable]
    public class TreeSpawn
    {
        public GameObject tree;
        public int num;
    }

    public List<TreeSpawn> trees;
    public int numTrees;
    public Terrain terrain;
    public bool spawnTrees = true;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnTrees)
        {
            GameObject p = new GameObject("Forest");
            TerrainCollider c = terrain.GetComponent<TerrainCollider>();
            foreach (TreeSpawn ts in trees)
            {
                for (int i = 0; i < ts.num; i++)
                {
                    float x = UnityEngine.Random.Range(0, c.bounds.size.x);
                    float y = UnityEngine.Random.Range(0, c.bounds.size.y) - c.bounds.size.y / 2f;
                    float z = UnityEngine.Random.Range(0, c.bounds.size.z);
                    GameObject go = Instantiate<GameObject>(ts.tree);
                    go.transform.localRotation = Quaternion.Euler(-90, UnityEngine.Random.Range(0, 360), 0);
                    go.transform.localScale = Vector3.one * UnityEngine.Random.Range(60, 120);
                    go.transform.position = new Vector3(x, 0, z);
                    go.transform.parent = p.transform;   
                }
            }
        }
        gameObject.GetComponent<BugSpawner>().SpawnBugs();
    }
}
