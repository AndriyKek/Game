using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImenu : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject MainMenu;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Game()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void Options()
    {
        Time.timeScale = 1;
        OptionsMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
