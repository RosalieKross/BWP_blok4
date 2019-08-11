using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public bool isPaused;
    public GameObject pausePanel;
    public string MainMenu;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            ChangePause(); 
        }
    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            SoundManager.PlayeSound("OpenPanel");
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
            SoundManager.PlayeSound("OpenPanel");
        }
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(MainMenu);
        Time.timeScale = 1f;
    }
}
