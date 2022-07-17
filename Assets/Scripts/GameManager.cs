using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static int babiesFed = 0;
    public static int babiesTotal = 1;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void BabyFed()
    {
        babiesFed++;
        if(babiesFed >= babiesTotal)
        {
            GameWin();
        }
    }

    private static void GameWin()
    {
        SceneManager.LoadScene("WinScene");
    }
}
