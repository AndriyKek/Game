using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIOptions : MonoBehaviour
{
    public GameObject OptionsMenu;
    public GameObject MainMenu;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Exittt()
    {
        Time.timeScale = 1;
        OptionsMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
