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
    
    public void startGame() {
        SceneManager.LoadScene("FirstLevel");
    }
    
    public void goToBeginGame() {
        SceneManager.LoadScene("BeginLevel");
    }
    
    public void goToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void goToLeaderboard() {
        SceneManager.LoadScene("Leaderboard");
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
}
