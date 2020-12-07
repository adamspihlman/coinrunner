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
    public static int currentPowerup = 0; //0: no powerup, 1: coin, 2: jump, 3: invincibility
    public static int coinMultiplier = 1;
    public static int jumpMultiplier = 0;
    public static int isInvincible = 0;
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
    public const int NUM_LEVELS = 3;
    public static bool j = false;

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
        LeaderboardManager.AddToLeaderboard(getUsername(), getScore(), getLevel(), getColor(), getPowerup());
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

    public static int getPowerup()
    {
        if (!Globals.powerUpEnabled)
            return 0;
        else
            return currentPowerup;
    }

    public static void setPowerup(int powerup)
    {
        currentPowerup = powerup;
        if (powerup == 1) { powerUpEnabled = true;}
        else { powerUpEnabled = false; }
    }

    public static bool pressed() {
	
	Globals.j = true; 
	return j;
    }



}
