using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Script : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer sprite;
    void Start()
    {
    sprite = GetComponent<SpriteRenderer>();
    sprite.color = new Color(0, 0.8f , 1, 1);
    if(PlayerPrefs.GetString("color") == "black"){
       sprite.color = new Color(0.15f, 0.15f, 0.15f, 1);
       }
    else if(PlayerPrefs.GetString("color") == "green"){
       sprite.color = new Color(0, 1 , 0, 1);
       }
    else if(PlayerPrefs.GetString("color") == "red"){
       sprite.color = new Color(1, 0, 0, 1);
       }
    else if(PlayerPrefs.GetString("color") == "purple"){
       sprite.color = new Color(0.9f, 0 , 1, 1);
       }
    else{
        sprite.color = new Color(0, 0.8f , 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
