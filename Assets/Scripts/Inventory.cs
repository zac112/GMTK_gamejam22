using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<Bug> bugs = new List<Bug>();
    public GameObject[] icons;
    public Sprite noBug;

    public void AddBug(Bug bug)
    {
        if (!bug) return;

        bugs.Add(bug);
        UpdateUI();
    }
    public void RemoveBug()
    {
        bugs.RemoveAt(bugs.Count-1);
    }

    private void UpdateUI()
    {
        int i = 0;
        for (; i<bugs.Count;i++)
        {
            icons[i].GetComponent<Image>().sprite = bugs[i].sprite;
        }
        for (; i < icons.Length; i++)
        {
            icons[i].GetComponent<Image>().sprite = noBug;
        }
    }
}
