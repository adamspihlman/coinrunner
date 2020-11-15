using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControlScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void startLevelOne() {
        SceneManager.LoadScene("FirstLevel");
        Globals.setLevel(1);
    }
    
    public void startLevelTwo() {
        SceneManager.LoadScene("SecondLevel");
        Globals.setLevel(2);
    }
    
    public void goToBeginGame() {
        SceneManager.LoadScene("BeginLevel");
    }
    
    public void goToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void goToLeaderboard1() {
        SceneManager.LoadScene("Leaderboard1");
    }

    public void goToLeaderboard2() {
        SceneManager.LoadScene("Leaderboard2");
    }
    
    public void goToNameChange() {
        SceneManager.LoadScene("ChangeName");
    }
    
    public void goToSettings() {
        SceneManager.LoadScene("Settings");
    }
    
    public void goToAvatarSelect() {
        SceneManager.LoadScene("Avatar Select");
    }
    public void goToHowToPlay() {
        SceneManager.LoadScene("Tutorial");
    }
    public void playAgain(){
	if (Globals.getLevel() == 1){
	SceneManager.LoadScene("FirstLevel");
	}
	else if (Globals.getLevel() == 2){
	SceneManager.LoadScene("SecondLevel");
     	}
	}

}