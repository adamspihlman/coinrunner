using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeName : MonoBehaviour
{
    public InputField username_textBox;
    public int numUsers;
    public string[] usernames;

    void Start()
    {

        numUsers = PlayerPrefs.GetInt("numUsers", 0);
        if (numUsers > 0)
        {
            usernames = new string[numUsers];
            for (int index = 0; index < numUsers; index++)
            {
                usernames[index] = PlayerPrefs.GetString("User" + index, string.Empty);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveUserName()
    {
        var username = username_textBox.text;
        //TODO
        //need to add function to block bad words from being saved

        //permanentaly stores user in playerpres.data
        PlayerPrefs.SetString("User" + numUsers, username);
        numUsers++;
        PlayerPrefs.SetInt("numUsers", numUsers);

        Globals.setUsername(username);

        SceneManager.LoadScene("MainMenu");
    }
}
