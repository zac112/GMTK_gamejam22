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
        StartCoroutine(SelectChild());
    }

    public void Deactivate()
    {
        activated = false;
    }

    IEnumerator SelectChild()
    {
        if (activated) yield break;
        activated = true;
        babies[selectedChild].GetComponentInChildren<SpriteRenderer>().enabled = true;
        while (activated)
        {
            if (!babies[selectedChild])
            {
                babies.RemoveAt(selectedChild);
                selectedChild = 0;
            }
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Inventory inv = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
                    if (inv.HasBugs())
                    {
                        inv.RemoveBug();
                        babies[selectedChild].GetComponent<BabyBird>().EatFood();
                    }
                    yield return null;
                    continue;
                }
                babies[selectedChild].GetComponentInChildren<SpriteRenderer>().enabled = false;

                int movement = 0;
                if (Input.GetKeyDown(KeyCode.LeftArrow)) movement = -1;
                if (Input.GetKeyDown(KeyCode.RightArrow)) movement = 1;
                if (Input.GetKeyDown(KeyCode.P)) {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>().AddBug(GameObject.FindObjectOfType<Bug>());
                }
                selectedChild = (selectedChild + movement + babies.Count) % babies.Count;

                babies[selectedChild].GetComponentInChildren<SpriteRenderer>().enabled = true;
            }
            yield return null;
        }
    }
}
