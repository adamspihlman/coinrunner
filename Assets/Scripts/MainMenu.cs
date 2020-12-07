using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainMenu : MonoBehaviour
{

    public Text welcomeLbl;
    public GameObject SoundOnButton;
    public GameObject SoundOffButton;
    public string[] nouns;
    public string[] adjs;

    void awake()
    {

    }
    void Start()
    {
        if (AudioListener.volume == 0) {
            SoundOnButton.gameObject.SetActive(false);
            SoundOffButton.gameObject.SetActive(true);
        } else {
            SoundOnButton.gameObject.SetActive(true);
            SoundOffButton.gameObject.SetActive(false);
        }

        var noun_reader = new StreamReader("Assets/nouns.txt");
        var raw_nouns = noun_reader.ReadToEnd();
        noun_reader.Close();

        nouns = raw_nouns.Split("\n"[0]);

        var adjs_reader = new StreamReader("Assets/adjectives.txt");
        var raw_adjs = adjs_reader.ReadToEnd();
        adjs_reader.Close();

        adjs = raw_adjs.Split("\n"[0]);
        if(!Globals.isUsernameSet)
            generateUsername();
        else
            welcomeLbl.text = "Welcome To Coin Runner, " + Globals.getUsername() + "!";
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void AdjustVolume () {
        Debug.Log("AudioListener.volume: " + AudioListener.volume);
        if (AudioListener.volume == 0) {
            AudioListener.volume = 1;
            SoundOnButton.gameObject.SetActive(true);
            SoundOffButton.gameObject.SetActive(false);
        } else {
            AudioListener.volume = 0;
            SoundOnButton.gameObject.SetActive(false);
            SoundOffButton.gameObject.SetActive(true);
        }
    }

    public void generateUsername()
    {
        var i = Random.Range(0, 911);// adjs[0] - adjs[911]
        var adj = adjs[i];

        var j = Random.Range(0, 1434);// nouns[0] - nouns[1434]
        var noun = nouns[j];

        var username = adj + noun;
        Globals.setUsername(username);
        welcomeLbl.text = "Welcome To Coin Runner, " + username + "!";
    }
}
