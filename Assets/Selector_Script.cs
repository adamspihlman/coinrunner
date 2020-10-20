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
private Vector3 ChrPos;
private Vector3 OffScreen;
private int character_int = 1;
private SpriteRenderer RedRend, BlueRend, GreenRend, PurpleRend, NormRend;

private void Awake(){
    ChrPos = Alien.transform.position;
    OffScreen = GAlien.transform.position;
    RedRend = RAlien.GetComponent<SpriteRenderer>();
    BlueRend = BAlien.GetComponent<SpriteRenderer>();
    PurpleRend = PAlien.GetComponent<SpriteRenderer>();
    GreenRend = GAlien.GetComponent<SpriteRenderer>();
    NormRend = Alien.GetComponent<SpriteRenderer>();
    PlayerPrefs.SetString("color","blue");
}

public void NextCharacter(){
switch(character_int){
    case 1:
        NormRend.enabled = false;
        Alien.transform.position = OffScreen;
        BAlien.transform.position = ChrPos;
        BlueRend.enabled = true;
        character_int++;
        PlayerPrefs.SetString("color","black");
        break;
    case 2:
        BlueRend.enabled = false;
        BAlien.transform.position = OffScreen;
        RAlien.transform.position = ChrPos;
        RedRend.enabled = true;
        character_int++;
        PlayerPrefs.SetString("color","red");
        break;
    case 3:
        RedRend.enabled = false;
        RAlien.transform.position = OffScreen;
        GAlien.transform.position = ChrPos;
        GreenRend.enabled = true;
        character_int++;
        PlayerPrefs.SetString("color","green");
        break;
    case 4:
        GreenRend.enabled = false;
        GAlien.transform.position = OffScreen;
        PAlien.transform.position = ChrPos;
        PurpleRend.enabled = true;
        character_int++;
        PlayerPrefs.SetString("color","purple");
        break;
    case 5:
        PurpleRend.enabled = false;
        PAlien.transform.position = OffScreen;
        Alien.transform.position = ChrPos;
        NormRend.enabled = true;
        character_int++;
        PlayerPrefs.SetString("color","blue");
        resetint();
        break;
    default:
        resetint();
        break;
}
}

public void PreviousCharacter(){
switch(character_int){
    case 1:
        NormRend.enabled = false;
        Alien.transform.position = OffScreen;
        PAlien.transform.position = ChrPos;
        PurpleRend.enabled = true;
        character_int--;
        PlayerPrefs.SetString("color","purple");
        resetint();
        break;
    case 2:
        BlueRend.enabled = false;
        BAlien.transform.position = OffScreen;
        Alien.transform.position = ChrPos;
        NormRend.enabled = true;
        PlayerPrefs.SetString("color","blue");
        character_int--;
        break;
    case 3:
        RedRend.enabled = false;
        RAlien.transform.position = OffScreen;
        BAlien.transform.position = ChrPos;
        BlueRend.enabled = true;
        PlayerPrefs.SetString("color","black");
        character_int--;
        break;
    case 4:
        GreenRend.enabled = false;
        GAlien.transform.position = OffScreen;
        RAlien.transform.position = ChrPos;
        RedRend.enabled = true;
        character_int--;
        PlayerPrefs.SetString("color","red");
        break;
    case 5:
        PurpleRend.enabled = false;
        PAlien.transform.position = OffScreen;
        GAlien.transform.position = ChrPos;
        GreenRend.enabled = true;
        character_int--;
        PlayerPrefs.SetString("color","green");
        break;
    default:
    resetint();
        break;
}
}


private void resetint(){
    if (character_int >= 5){
        character_int = 1;
    }
    else{
        character_int = 5;
    }
}






}



