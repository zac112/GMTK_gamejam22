using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBird : MonoBehaviour
{
    public float hunger = 0f;

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
                Die();
            }
        }
    }

    public void EatFood()
    {
        hunger = 0;
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
