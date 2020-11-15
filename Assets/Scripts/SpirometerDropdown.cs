using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpirometerDropdown : MonoBehaviour
{

    
    public void HandleInput(int val)
    {
        Debug.Log("val: " + val);
        if (val == 1) {
            Debug.Log("Bad Breath Selected");
        }
        if (val == 2) {
            Debug.Log("Poorer Breath Selected");
        }
        if (val == 3) {
            Debug.Log("Poor Breath Selected");
        }  
        if (val == 4) {
            Debug.Log("Good Breath Selected");
        }
        if (val == 5) {
            Debug.Log("Better Breath Selected");
        }
        if (val == 6) {
            Debug.Log("Best Breath Selected");
        }
        
    }

}
