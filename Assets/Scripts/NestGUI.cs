using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestGUI : MonoBehaviour
{
    int selectedChild = 0;
    public List<GameObject> babies;
    public bool activated = false;

    private void Start()
    {
        babies.RemoveAll((a) => !a.activeSelf);
    }

    public void Activate()
    {
        activated = true;
        StartCoroutine(SelectChild());
    }

    public void Deactivate()
    {
        activated = false;
    }

    IEnumerator SelectChild()
    {
        babies[selectedChild].GetComponentInChildren<SpriteRenderer>().enabled = true;
        while (activated)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {

                    continue;
                }
                babies[selectedChild].GetComponentInChildren<SpriteRenderer>().enabled = false;

                int movement = 0;
                if (Input.GetKeyDown(KeyCode.LeftArrow)) movement = -1;
                if (Input.GetKeyDown(KeyCode.RightArrow)) movement = 1;
                selectedChild = (selectedChild + movement + babies.Count) % babies.Count;

                babies[selectedChild].GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
            yield return null;
        }
    }
}
