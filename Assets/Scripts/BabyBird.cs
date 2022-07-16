using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBird : MonoBehaviour
{
    public float hunger = 0f;
    public int food = 0;
    public GameObject filledBaby;
    public GameObject hungryBaby;

    void Start()
    {
        StartCoroutine(GetHungrier());   
    }

    // Update is called once per frame
    IEnumerator GetHungrier()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            hunger += 0.01f;

            if (hunger >= 1f)
            {
                //Die();
            }
        }
    }

    public void EatFood()
    {
        hunger = 0;
        food += 1;
        if (food >= 3)
        {
            hungryBaby.GetComponent<MeshRenderer>().enabled = false;
            filledBaby.GetComponent<MeshRenderer>().enabled = true;
            GameManager.BabyFed();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
