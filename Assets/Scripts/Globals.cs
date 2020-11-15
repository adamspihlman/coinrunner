using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static string username;
    public static bool powerUpEnabled = false;
    public static bool isUsernameSet = false;
    public static int currentScore = 0;
    public static int currentColor = PLAYER_BLUE;
    public static int currentLevel = 0;
    public static int coinMultiplier = 1;
    public static int jumpMultiplier = 0;
    public static int numLives = 1;
    public const int PLAYER_BLUE = 1000;
    public const int PLAYER_BLACK = 1001;
    public const int PLAYER_RED = 1002;
    public const int PLAYER_GREEN = 1003;
    public const int PLAYER_PURPLE = 1004;
    public const int PLAYER_YELLOW = 1005;
    public const int PLAYER_ORANGE = 1006;
    public const int PLAYER_WHITE = 1007;
    public const int PLAYER_NAVY = 1008;
    public const int NUM_LEVELS = 2;

    public static void setUsername(string text)
    {
        username = text;
        isUsernameSet = true;
    }

    public static string getUsername()
    {
        return username;
    }
    public static void resetScore()
    {
        currentScore = 0;
    }

    public static void incrementScore()
    {
        currentScore = currentScore + coinMultiplier;
    }

    public static int getScore()
    {
        return currentScore;
    }

    public static void saveScore()
    {
        LeaderboardManager.AddToLeaderboard(getUsername(), getScore(), getLevel(), getColor());
    }

    public static void setColor(int color)
    {
        currentColor = color;
    }

    public static int getColor()
    {
        return currentColor;
    }

    public static void setLevel(int level)
    {
        currentLevel = level;
    }

    public static int getLevel()
    {
        return currentLevel;
    }
}
