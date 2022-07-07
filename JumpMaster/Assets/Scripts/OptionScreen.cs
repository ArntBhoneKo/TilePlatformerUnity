using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionScreen : MonoBehaviour
{
    public TMP_Text masterLabel, musicLabel, sfxLabel;
    public Slider  masterSlider, musicSlider, sfxSlider;
    
    void Start() 
    {
        float mvol = 0f;
        FindObjectOfType<AudioManager>().mainMixer.GetFloat("MasterVol", out mvol);
        masterSlider.value = mvol;

        float bgvol = 0f;
        FindObjectOfType<AudioManager>().mainMixer.GetFloat("BGVol", out bgvol);
        masterSlider.value = bgvol;

        float SFXvol = 0f;
        FindObjectOfType<AudioManager>().mainMixer.GetFloat("SFXVol", out SFXvol);
        masterSlider.value = SFXvol;

        masterLabel.text = Mathf.RoundToInt((((masterSlider.value + 50) / 70) * 100)).ToString();

        musicLabel.text = Mathf.RoundToInt((((musicSlider.value + 50) / 70) * 100)).ToString();

        sfxLabel.text = Mathf.RoundToInt((((sfxSlider.value + 50) / 70) * 100)).ToString();
        
    }

    public void SetMasterVol()
    {
        masterLabel.text = Mathf.RoundToInt((((masterSlider.value + 50) / 70) * 100)).ToString();

        FindObjectOfType<AudioManager>().mainMixer.SetFloat("MasterVol", masterSlider.value);

        PlayerPrefs.SetFloat("MasterVol" , masterSlider.value);
    }

    public void SetMusicVol()
    {
        musicLabel.text = Mathf.RoundToInt((((musicSlider.value + 50) / 70) * 100)).ToString();

        FindObjectOfType<AudioManager>().mainMixer.SetFloat("BGVol", musicSlider.value);

        PlayerPrefs.SetFloat("BGVol", musicSlider.value);
    }

    public void SetSFXVol()
    {
        sfxLabel.text = Mathf.RoundToInt((((sfxSlider.value + 50) / 70) * 100)).ToString();

        FindObjectOfType<AudioManager>().mainMixer.SetFloat("SFXVol", sfxSlider.value);

        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);
    }
}
