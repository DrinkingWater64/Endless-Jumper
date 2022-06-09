using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{

    public int _highScore;
    public int _score;

    public static GameState instance = null; 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Invoke("GameOverTime", 1f);
    }

    public void GoMenu()
    {
        Invoke("GoMenuTime", 1f);
    }

    public void GoGame()
    {
        Invoke("GoGameTime", 1f);
    }

    void GameOverTime()
    {
        SceneManager.LoadScene("GameOver");
    }

    void GoGameTime()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("game load");
    }

    void GoMenuTime()
    {
        SceneManager.LoadScene("Menu");
    }


}
