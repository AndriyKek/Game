using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject PausePanel;
    
    void Start()
    {
        
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
