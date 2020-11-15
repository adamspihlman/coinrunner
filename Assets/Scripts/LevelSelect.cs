using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{

    public GameObject spirometerPopup;
    // Start is called before the first frame update
    void Start()
    {
        spirometerPopup.SetActive(true);
    }
    
    public void StartSpirometerUse() {
        spirometerPopup.SetActive(true);
    }
    
    public void EndSpirometerUse() {
        spirometerPopup.SetActive(false);
        Debug.Log("Closing the popup");
    }
    
}
