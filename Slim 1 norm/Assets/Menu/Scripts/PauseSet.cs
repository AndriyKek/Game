using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSet : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject PanelVolume;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PausePanel.SetActive(false);
            PanelVolume.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Countinue()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
    }
    public void Exitt()
    {
        SceneManager.LoadScene(0);
    }
    public void Refresh()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Setings()
    {
        Time.timeScale = 0;
        PanelVolume.SetActive(true);
    }
    public void Setingsback()
    {
        Time.timeScale = 0;
        PanelVolume.SetActive(false);

        if (Input.GetButton("Refresh"))
        {
            PanelVolume.SetActive(false);
        }
     }
}

  