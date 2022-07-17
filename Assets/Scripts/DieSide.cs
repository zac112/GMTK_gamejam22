using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DieSide : MonoBehaviour
{
    public int side;

    private void OnTriggerEnter(Collider collision)
    {
        GameManager.babiesTotal = 7 - side;
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        TextMesh t = GameObject.Find("StartText").GetComponent<TextMesh>();
        for (int timer = 5; timer > 0; timer--)
        {
            t.text = $"You rolled {GameManager.babiesTotal}\nThe game will start in {timer}";
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("SampleScene");  
    }
}
