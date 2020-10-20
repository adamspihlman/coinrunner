using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static string username;
    public static bool isUsernameSet = false;
    public static int currentScore = 0;

    public static void setUsername(string text)
    {
        username = text;
        isUsernameSet = true;
    }

    public static void resetScore()
    {
        currentScore = 0;
    }

    public static void incrementScore()
    {
        currentScore++;
    }

    public static int getScore()
    {
        return currentScore;
    }

    public static void saveScore()
    {
        var userNum = PlayerPrefs.GetInt("numUsers", 0) - 1;
        var key = "User" + userNum + ".Score";
        var lastScore = PlayerPrefs.GetInt(key, -1);
        if (lastScore == -1)
        {
            PlayerPrefs.SetInt(key, currentScore);
        }
        else
        {
            if(currentScore > lastScore)
            {
                PlayerPrefs.SetInt(key, currentScore);
            }
        }
    }
}
