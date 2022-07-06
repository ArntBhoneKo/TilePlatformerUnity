using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioClip coinPickupSFX;
    [SerializeField] public AudioClip gunShotSFX;
    [SerializeField] public AudioClip playerDeathSFX;
    [SerializeField] public AudioClip enemyDeathSFX;
    [SerializeField] public AudioClip winSFX;
    [SerializeField] public AudioClip jumpSFX;
    [SerializeField] public AudioClip clickSFX;

    void Awake()
    {
        int numAudioManager = FindObjectsOfType<AudioManager>().Length;
        if (numAudioManager > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void CoinPickupAudio() 
    {
        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
    }

    public void GunShotAudio() 
    {
        AudioSource.PlayClipAtPoint(gunShotSFX, Camera.main.transform.position);
    }

    public void PlayerDeathAudio() 
    {
        AudioSource.PlayClipAtPoint(playerDeathSFX, Camera.main.transform.position);
    }

    public void EnemyDeathAudio() 
    {
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);
    }

    public void WinAudio() 
    {
        AudioSource.PlayClipAtPoint(winSFX, Camera.main.transform.position);
    }

    public void JumpAudio() 
    {
        AudioSource.PlayClipAtPoint(jumpSFX, Camera.main.transform.position);
    }

    public void ClickAudio() 
    {
        AudioSource.PlayClipAtPoint(clickSFX, new Vector3(-13,-9,-1));
    }
}
