using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPlay = true;
    public static GameManager Instance { get; private set; }
    public int score = 0;
    public int life = 3;
    [HideInInspector] public string nameScene;
    public float recordScore = 0f;


    void Start()
    {
        recordScore = PlayerPrefs.GetInt("Score", 0);
        nameScene = SceneManager.GetActiveScene().name;
    }



    void Awake()
    {
        // Destroy old Instace
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetScore(int initialScore)
    {
        score += initialScore;
    }

    public bool IsPlayActive()
    {
        return isPlay;
    }

    public bool IsGameOver()
    {
        return !isPlay;
    }
    public void EndGame()
    {
        // Set Flag
        isPlay = false;

        // Print Message
        Debug.Log("GAME OVER ... You Score: " + score);

        // Reload scene
        StartCoroutine(ReloadScene(2));
    }

    private IEnumerator ReloadScene(float delay)
    {
        // Wait
        yield return new WaitForSeconds(delay);

        // Reload Scene
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
}
