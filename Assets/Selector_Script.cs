using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector_Script : MonoBehaviour
{
public GameObject RAlien;
public GameObject GAlien;
public GameObject BAlien;
public GameObject PAlien;
public GameObject Alien;
public GameObject YAlien;
public GameObject OAlien;
public GameObject WAlien;
public GameObject NAlien;
private Vector3 ChrPos;
private Vector3 OffScreen;
private int character_int = Globals.getColor();
private SpriteRenderer RedRend, BlueRend, GreenRend, PurpleRend, NormRend, new1rend, new2rend, new3rend, new4rend;

private void Awake(){
    ChrPos = Alien.transform.position;
    OffScreen = GAlien.transform.position;
    RedRend = RAlien.GetComponent<SpriteRenderer>();
    BlueRend = BAlien.GetComponent<SpriteRenderer>();
    PurpleRend = PAlien.GetComponent<SpriteRenderer>();
    GreenRend = GAlien.GetComponent<SpriteRenderer>();
    NormRend = Alien.GetComponent<SpriteRenderer>();
    new1rend = YAlien.GetComponent<SpriteRenderer>();
    new2rend = OAlien.GetComponent<SpriteRenderer>();
    new3rend = WAlien.GetComponent<SpriteRenderer>();
    new4rend = NAlien.GetComponent<SpriteRenderer>();

switch(character_int){
    
    case Globals.PLAYER_BLUE:
    
    break;
    case Globals.PLAYER_BLUE + 1:
    NormRend.enabled = false;
    Alien.transform.position = OffScreen;
    BAlien.transform.position = ChrPos;
    BlueRend.enabled = true;
    
    break;
    
    case Globals.PLAYER_BLUE + 2:
    NormRend.enabled = false;
    Alien.transform.position = OffScreen;
    RAlien.transform.position = ChrPos;
    RedRend.enabled = true;
   
    break;
    
    case Globals.PLAYER_BLUE + 3:
    NormRend.enabled = false;
    Alien.transform.position = OffScreen;
    GAlien.transform.position = ChrPos;
    GreenRend.enabled = true;

    break;
    
    case Globals.PLAYER_BLUE + 4:
    NormRend.enabled = false;
    Alien.transform.position = OffScreen;
    PAlien.transform.position = ChrPos;
    PurpleRend.enabled = true;

    break;
    
    case Globals.PLAYER_BLUE + 5:
    NormRend.enabled = false;
    Alien.transform.position = OffScreen;
    YAlien.transform.position = ChrPos;
    new1rend.enabled = true;

    break;
    
    case Globals.PLAYER_BLUE + 6:
    NormRend.enabled = false;
    Alien.transform.position = OffScreen;
    OAlien.transform.position = ChrPos;
    new2rend.enabled = true;

    break;
    
    case Globals.PLAYER_BLUE + 7:
    NormRend.enabled = false;
    Alien.transform.position = OffScreen;
    WAlien.transform.position = ChrPos;
    new3rend.enabled = true;
    
    break;
    
    case Globals.PLAYER_BLUE + 8:
    NormRend.enabled = false;
    Alien.transform.position = OffScreen;
    NAlien.transform.position = ChrPos;
    new4rend.enabled = true;

    break;
}

}

public void NextCharacter(){
switch(character_int){
    case Globals.PLAYER_BLUE:
        NormRend.enabled = false;
        Alien.transform.position = OffScreen;
        BAlien.transform.position = ChrPos;
        BlueRend.enabled = true;
        character_int++;
        Globals.setColor(Globals.PLAYER_BLACK);
        break;
    case Globals.PLAYER_BLUE + 1:
        BlueRend.enabled = false;
        BAlien.transform.position = OffScreen;
        RAlien.transform.position = ChrPos;
        RedRend.enabled = true;
        character_int++;
        Globals.setColor(Globals.PLAYER_RED);
        break;
    case Globals.PLAYER_BLUE + 2:
        RedRend.enabled = false;
        RAlien.transform.position = OffScreen;
        GAlien.transform.position = ChrPos;
        GreenRend.enabled = true;
        character_int++;
        Globals.setColor(Globals.PLAYER_GREEN);
        break;
    case Globals.PLAYER_BLUE + 3:
        GreenRend.enabled = false;
        GAlien.transform.position = OffScreen;
        PAlien.transform.position = ChrPos;
        PurpleRend.enabled = true;
        character_int++;
        Globals.setColor(Globals.PLAYER_PURPLE);
        break;
    
    case Globals.PLAYER_BLUE + 4:
        PurpleRend.enabled = false;
        PAlien.transform.position = OffScreen;
        YAlien.transform.position = ChrPos;
        new1rend.enabled = true;
        character_int++;
        Globals.setColor(Globals.PLAYER_YELLOW);
        break;
    case Globals.PLAYER_BLUE + 5:
        new1rend.enabled = false;
        YAlien.transform.position = OffScreen;
        OAlien.transform.position = ChrPos;
        new2rend.enabled = true;
        character_int++;
        Globals.setColor(Globals.PLAYER_ORANGE);
        break;
    case Globals.PLAYER_BLUE + 6:
        new2rend.enabled = false;
        OAlien.transform.position = OffScreen;
        WAlien.transform.position = ChrPos;
        new3rend.enabled = true;
        character_int++;
        Globals.setColor(Globals.PLAYER_WHITE);
        break;
    case Globals.PLAYER_BLUE + 7:
        new3rend.enabled = false;
        WAlien.transform.position = OffScreen;
        NAlien.transform.position = ChrPos;
        new4rend.enabled = true;
        character_int++;
        Globals.setColor(Globals.PLAYER_NAVY);
        break;
    case Globals.PLAYER_BLUE + 8:
        new4rend.enabled = false;
        NAlien.transform.position = OffScreen;
        Alien.transform.position = ChrPos;
        NormRend.enabled = true;
        character_int++;
        Globals.setColor(Globals.PLAYER_BLUE); // if more colors added remove this line and add //whatever = Globals.PLAYER_BLUE + 5
        break;
        resetint();// if more colors added remove this line and add it to higest #'ed color
        break;
    //add more colors here
    default:
        resetint();
        break;
}
}

public void PreviousCharacter(){
switch(character_int){
    case Globals.PLAYER_BLUE:
        NormRend.enabled = false;
        Alien.transform.position = OffScreen;
        NAlien.transform.position = ChrPos;
        new4rend.enabled = true;
        character_int--;
        Globals.setColor(Globals.PLAYER_NAVY); // change this line for largest #'ed color if more colors added
        resetint();
        break;
    case Globals.PLAYER_BLUE + 1:
        BlueRend.enabled = false;
        BAlien.transform.position = OffScreen;
        Alien.transform.position = ChrPos;
        NormRend.enabled = true;
        Globals.setColor(Globals.PLAYER_BLUE);
        character_int--;
        break;
    case Globals.PLAYER_BLUE + 2:
        RedRend.enabled = false;
        RAlien.transform.position = OffScreen;
        BAlien.transform.position = ChrPos;
        BlueRend.enabled = true;
        Globals.setColor(Globals.PLAYER_BLACK);
        character_int--;
        break;
    case Globals.PLAYER_BLUE + 3:
        GreenRend.enabled = false;
        GAlien.transform.position = OffScreen;
        RAlien.transform.position = ChrPos;
        RedRend.enabled = true;
        character_int--;
        Globals.setColor(Globals.PLAYER_RED);
        break;
    case Globals.PLAYER_BLUE + 4:
        PurpleRend.enabled = false;
        PAlien.transform.position = OffScreen;
        GAlien.transform.position = ChrPos;
        GreenRend.enabled = true;
        character_int--;
        Globals.setColor(Globals.PLAYER_GREEN);
        break;
    case Globals.PLAYER_BLUE + 5:
        new1rend.enabled = false;
        YAlien.transform.position = OffScreen;
        PAlien.transform.position = ChrPos;
        PurpleRend.enabled = true;
        character_int--;
        Globals.setColor(Globals.PLAYER_PURPLE);
        break;
    case Globals.PLAYER_BLUE + 6:
        new2rend.enabled = false;
        OAlien.transform.position = OffScreen;
        YAlien.transform.position = ChrPos;
        new1rend.enabled = true;
        character_int--;
        Globals.setColor(Globals.PLAYER_YELLOW);
        break;
    case Globals.PLAYER_BLUE + 7:
        new3rend.enabled = false;
        WAlien.transform.position = OffScreen;
        OAlien.transform.position = ChrPos;
        new2rend.enabled = true;
        character_int--;
        Globals.setColor(Globals.PLAYER_ORANGE);
        break;
    case Globals.PLAYER_BLUE + 8:
        new4rend.enabled = false;
        NAlien.transform.position = OffScreen;
        WAlien.transform.position = ChrPos;
        new3rend.enabled = true;
        character_int--;
        Globals.setColor(Globals.PLAYER_WHITE);
        break;
        
        
    // add additional colors here
    default:
    resetint();
        break;
}
}

    
private void resetint(){
    if (character_int > Globals.PLAYER_NAVY)//change to largest # color if more colors added
    {
        character_int = Globals.PLAYER_BLUE;
    }
    else if (character_int < Globals.PLAYER_BLUE)
    {
        character_int = Globals.PLAYER_NAVY;// change to largest # color if more colors added
    }
}






}



