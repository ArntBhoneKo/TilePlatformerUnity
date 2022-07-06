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
}
