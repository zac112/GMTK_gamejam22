using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DieSide : MonoBehaviour
{
    public int side;
    public bool firstTime = true;

    private void OnTriggerEnter(Collider collision)
    {
        if(firstTime) return;

        GameManager.babiesTotal = 7 - side;
        StartCoroutine(StartGame());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            firstTime = false;
        }
    }
    IEnumerator StartGame()
    {
        TMP_Text t = GameObject.Find("StartText").GetComponent<TMP_Text>();
        for (int timer = 5; timer > 0; timer--)
        {
            t.text = $"You rolled {GameManager.babiesTotal}\nThe game will start in {timer}";
            yield return new WaitForSeconds(1);
        }
        SceneManager.LoadScene("SampleScene");  
    }
}
