using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static int babiesFed = 0;
    public static int babiesTotal = 1;
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

    }
}
