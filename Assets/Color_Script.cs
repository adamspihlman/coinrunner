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
        switch (Globals.getColor())
        {
            case Globals.PLAYER_BLACK:
                sprite.color = new Color(0.15f, 0.15f, 0.15f, 1);
                break;
            case Globals.PLAYER_RED:
                sprite.color = new Color(1, 0, 0, 1);
                break;
            case Globals.PLAYER_GREEN:
                sprite.color = new Color(0, 1, 0, 1);
                break;
            case Globals.PLAYER_PURPLE:
                sprite.color = new Color(0.9f, 0, 1, 1);
                break;
            case Globals.PLAYER_YELLOW:
                sprite.color = new Color(1, 1, 0, 1);
                break;
            case Globals.PLAYER_ORANGE:
                sprite.color = new Color(1, 0.4f, 0, 1);
                break;
            case Globals.PLAYER_WHITE:
                sprite.color = new Color(1, 1, 1, 1);
                break;
            case Globals.PLAYER_NAVY:
                sprite.color = new Color(0, 0, 1, 1);
                break;
            default:
                sprite.color = new Color(0, 0.8f, 1, 1); //blue
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
