using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveColor : MonoBehaviour
{
    public string color;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void colors(){
        color = PlayerPrefs.GetString("color");
     }
}
