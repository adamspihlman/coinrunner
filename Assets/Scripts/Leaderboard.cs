using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Leaderboard : MonoBehaviour
{
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        var numRows = PlayerPrefs.GetInt("numUsers", 0);
        var str = "";

        for(int i = 0; i < numRows; i++)
        {
            var temp = " ";
            temp = PlayerPrefs.GetString("User" + i, "");
            var key = "User" + i + ".Score";
            var score = PlayerPrefs.GetInt(key, 0);
            temp = temp + ": " + score + " ///";
            str = str + temp;
        }
        scoreText.text = str;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
