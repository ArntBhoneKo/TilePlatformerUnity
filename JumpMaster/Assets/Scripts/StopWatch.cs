using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class StopWatch : MonoBehaviour
{
    bool stopWatchActive = false;
    float currentTime;
    [SerializeField] float levelLoadDelay;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI finishTimeText;
    public TextMeshProUGUI winLevelText;
    public TextMeshProUGUI loseLevelText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopWatchActive == true)
        {
            currentTime = currentTime + Time.deltaTime;
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        currentTimeText.text = time.ToString(@"mm\:ss\:ff");
        finishTimeText.text = time.ToString(@"mm\:ss\:ff");
    }

    public void ShowWinLevelText()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        winLevelText.text = "Level " + currentSceneIndex.ToString() + " Complete!";
    }

    public void ShowLoseLevelText()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        loseLevelText.text = "Level " + currentSceneIndex.ToString() + " Failed";
    }

    public void StartStopwatch()
    {
        stopWatchActive = true;
    }

    public void StopStopwatch()
    {
        stopWatchActive = false;
    }

    public void ResetStopwatch()
    {
        currentTime = 0;
    }

    public void NextLevel()
    {
        ResetStopwatch();
        FindObjectOfType<MainMenu>().CloseWinMenu();
        FindObjectOfType<AudioManager>().ClickAudio();
        StartCoroutine(LoadNextLevel());
    }

    public void RetryLevel()
    {
        ResetStopwatch();
        FindObjectOfType<MainMenu>().CloseWinMenu();
        FindObjectOfType<MainMenu>().CloseLoseMenu();
        FindObjectOfType<AudioManager>().ClickAudio();
        FindObjectOfType<GameSession>().ResetLife();
        FindObjectOfType<StopWatch>().StartStopwatch();
        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }

    public void BackToHome()
    {
        ResetStopwatch();
        FindObjectOfType<MainMenu>().CloseWinMenu();
        FindObjectOfType<MainMenu>().CloseLoseMenu();
        FindObjectOfType<AudioManager>().ClickAudio();
        FindObjectOfType<GameSession>().ResetGameSession();
    }
    
    IEnumerator LoadNextLevel()
    {
        
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        FindObjectOfType<StopWatch>().StartStopwatch();

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
            FindObjectOfType<GameSession>().ResetGameSession();
        }
        
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(nextSceneIndex);
    }
    
}
