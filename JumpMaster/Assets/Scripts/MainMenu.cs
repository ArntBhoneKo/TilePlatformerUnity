using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject realMenu;
    public GameObject levelsMenu;
    public GameObject controlsMenu;
    [SerializeField] float loadDelay = 1f;

    private void Start() 
    {
        optionsMenu.SetActive(false);
        levelsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        realMenu.SetActive(true);
    }

    public void OpenOptions()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        realMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        optionsMenu.SetActive(false);
        realMenu.SetActive(true);
    }

    public void OpenLevelMenu()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        realMenu.SetActive(false);
        levelsMenu.SetActive(true);
    }

    public void CloseLevelMenu()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        levelsMenu.SetActive(false);
        realMenu.SetActive(true);
    }

    public void OpenControlsMenu()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        realMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void CloseControlsMenu()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        controlsMenu.SetActive(false);
        realMenu.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(LoadLevelFromMenu(1));
    }

    public void Startlvl2()
    {
        StartCoroutine(LoadLevelFromMenu(2));
    }

    public void Startlvl3()
    {
        StartCoroutine(LoadLevelFromMenu(3));
    }

    public void Startlvl4()
    {
        StartCoroutine(LoadLevelFromMenu(4));
    }

    IEnumerator LoadLevelFromMenu(int level)
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        yield return new WaitForSecondsRealtime(loadDelay);
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        StartCoroutine(ExitGame());
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        Application.Quit();
    }
}
