using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int playerScore = 0;
    public static int playerKeys = 0;

    public static void AddScore(int score) 
    {
        playerScore += score;
    }

    public static int GetScore() 
    {
        return playerScore;
    }

    public static void AddKey() 
    {
        playerKeys++;
    }

    public static void RemoveKey() 
    {
        if (playerKeys > 0)
        {
            playerKeys--;
        }
    }

    public static int GetKeys() 
    {
        return playerKeys;
    }

    public static bool HasKeys()
    {
        return playerKeys > 0;
    }

    public static void ResetStats()
    {
        playerScore = 0;
        playerKeys = 0;
    }
}
