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
    public GameObject credits;
    public GameObject winMenu;
    public GameObject loseMenu;
    [SerializeField] float loadDelay = 1f;

    void Awake()
    {
        int numMainMenus = FindObjectsOfType<MainMenu>().Length;
        if (numMainMenus > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() 
    {
        FindObjectOfType<GameSession>().mainCanvas.SetActive(false);
        optionsMenu.SetActive(false);
        levelsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
        credits.SetActive(false);
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

    public void OpenControls()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        realMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void CloseControls()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        controlsMenu.SetActive(false);
        realMenu.SetActive(true);
    }

    public void OpenCredits()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        realMenu.SetActive(false);
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        FindObjectOfType<AudioManager>().ClickAudio();
        credits.SetActive(false);
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

    public void OpenLoseMenu()
    {
        loseMenu.SetActive(true);
    }

    public void CloseLoseMenu()
    {
        loseMenu.SetActive(false);
    }

    public void OpenWinMenu()
    {
        winMenu.SetActive(true);
    }

    public void CloseWinMenu()
    {
        winMenu.SetActive(false);
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
        optionsMenu.SetActive(false);
        levelsMenu.SetActive(false);
        controlsMenu.SetActive(false);
        realMenu.SetActive(false);
        FindObjectOfType<GameSession>().mainCanvas.SetActive(true);
        FindObjectOfType<StopWatch>().StartStopwatch();
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
