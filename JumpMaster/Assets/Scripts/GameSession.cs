using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameSession : MonoBehaviour
{
    [SerializeField] int playerLives = 3;
    [SerializeField] float loadDelay = 1f;
    [SerializeField] int coin = 0;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if (numGameSessions > 1)
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
        livesText.text = playerLives.ToString();
        scoreText.text = coin.ToString();
    }

    
    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            TakeLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    public void AddToCoin(int pointsToAdd)
    {
        coin += pointsToAdd;
        if (coin >= 100)
        {
            coin = 0;
            playerLives++;
            livesText.text = playerLives.ToString();
        }
        scoreText.text = coin.ToString();
    }

    void ResetGameSession()
    {
        StartCoroutine(ResetLevel());
        FindObjectOfType<ScenePersist>().ResetScenePersist();
    }

    void TakeLife()
    {
        playerLives--;
        StartCoroutine(LoadLevel());
        livesText.text = playerLives.ToString();
    }

    IEnumerator LoadLevel()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    IEnumerator ResetLevel()
    {
        yield return new WaitForSecondsRealtime(loadDelay);
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

}
