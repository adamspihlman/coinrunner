using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

    public GameObject spirometerPopup;
    public GameObject areYouSurePopup;
    
    // Start is called before the first frame update
    void Start()
    {
        spirometerPopup.SetActive(true);
        areYouSurePopup.SetActive(false);
    }
    
    public void StartSpirometerUse() {
        areYouSurePopup.SetActive(false);
        spirometerPopup.SetActive(true);
    }
    
    public void EndSpirometerUse() {
        spirometerPopup.SetActive(false);
        // Debug.Log("Closing the popup");
    }
    
    public void skipButtonPressed() {
        areYouSurePopup.SetActive(true);
    }

    public void skipSpirometerUse()
    {
        EndSpirometerUse();
        Debug.Log("Hellllllo");
        Globals.powerUpEnabled = false;
        Globals.setPowerup(0);
        Globals.coinMultiplier = 1;
        Globals.isInvincible = 0;
        Globals.jumpMultiplier = 0;
    }
    
}
