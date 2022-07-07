using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{    
    void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().WinAudio();
            FindObjectOfType<MainMenu>().OpenWinMenu();
            FindObjectOfType<StopWatch>().StopStopwatch();
            FindObjectOfType<StopWatch>().ShowWinLevelText();
            FindObjectOfType<PlayerMovement>().StopInput();
        }
    }
    
}
