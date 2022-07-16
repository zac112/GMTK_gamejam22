using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    public List<GameObject> trees;
    public int numTrees;
    public Terrain terrain;

    // Start is called before the first frame update
    void Start()
    {
        GameObject p = new GameObject("Forest");
        TerrainCollider c = terrain.GetComponent<TerrainCollider>();
        for(int i=0; i<numTrees; i++)
        {

            float x = Random.Range(0, c.bounds.size.x);
            float y = Random.Range(0, c.bounds.size.y) - c.bounds.size.y / 2f; 
            float z = Random.Range(0, c.bounds.size.z);
            GameObject go = Instantiate<GameObject>(trees[Random.Range(0, trees.Count)]);
            go.transform.localRotation = Quaternion.Euler(-90, Random.Range(0,360), 0);
            go.transform.position = new Vector3(x, 0, z);
            go.transform.parent = p.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
