using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text welcomeLbl;
    public bool updatedLbl = false;
    // Start is called before the first frame update

    void awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Globals.isUsernameSet && !updatedLbl)
        {
            welcomeLbl.text = "Welcome to Coin Runner, " + Globals.username + "!";
            updatedLbl = true;
        }
    }
}
