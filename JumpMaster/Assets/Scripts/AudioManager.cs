using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] public AudioClip coinPickupSFX;
    [SerializeField] public AudioClip gunShotSFX;
    [SerializeField] public AudioClip playerDeathSFX;
    [SerializeField] public AudioClip enemyDeathSFX;
    [SerializeField] public AudioClip winSFX;
    [SerializeField] public AudioClip jumpSFX;
    [SerializeField] public AudioClip clickSFX;
    [SerializeField] AudioSource sfxSource;
    public AudioMixer mainMixer;
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

    void Start() 
    {
        if (PlayerPrefs.HasKey("MasterVol"))
        {
            mainMixer.SetFloat("MasterVol", PlayerPrefs.GetFloat("MasterVol"));
        }  

        if (PlayerPrefs.HasKey("BGVol"))
        {
            mainMixer.SetFloat("BGVol", PlayerPrefs.GetFloat("BGVol"));
        }  

        if (PlayerPrefs.HasKey("SFXVol"))
        {
            mainMixer.SetFloat("SFXVol", PlayerPrefs.GetFloat("SFXVol"));
        }  
    }

    public void CoinPickupAudio() 
    {
        sfxSource.PlayOneShot(coinPickupSFX, 1f);
    }

    public void GunShotAudio() 
    {
        sfxSource.PlayOneShot(gunShotSFX, 1f);
    }

    public void PlayerDeathAudio() 
    {
        sfxSource.PlayOneShot(playerDeathSFX, 1f);
    }

    public void EnemyDeathAudio() 
    {
        sfxSource.PlayOneShot(enemyDeathSFX, 1f);
    }

    public void WinAudio() 
    {
        sfxSource.PlayOneShot(winSFX, 1f);
    }

    public void JumpAudio() 
    {
        sfxSource.PlayOneShot(jumpSFX, 1f);
    }

    public void ClickAudio() 
    {
        sfxSource.PlayOneShot(clickSFX, 1f);
    }
}
