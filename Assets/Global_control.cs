using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public static GlobalControl Instance;
    public string color;

    void Awake ()
       {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy (gameObject);
        }
      }
      public void SavePlayer()
        {
        GlobalControl.Instance.color = color;
        }
        
        void Start()
        {
        color = GlobalControl.Instance.color;
        }
        
}
