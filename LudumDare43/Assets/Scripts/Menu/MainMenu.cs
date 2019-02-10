using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool Paused = false;

    public GameObject MenuUI;
    public GameObject GodUI;

    //public GameObject ResumeButton;
    public GameObject RestartButton;
    public GameObject PlayButton;
    public GameObject SceneParametersManager;

    private void Awake()
    {
        RestartButton.SetActive(false);
        Pause();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                Resume();
            }
            else
            {
                Pause();
                SetButtonLoadOut(false);
            }
        }
    }

    private void SetButtonLoadOut(bool showButton)
    {
        PlayButton.SetActive(showButton);
        RestartButton.SetActive(!showButton);
    }

    void Resume()
    {
        Debug.Log("Resumed!");
        MenuUI.SetActive(false);
        GodUI.SetActive(true);
        Time.timeScale = 1f;
        Paused = false;
    }

    void Pause()
    {
        Debug.Log("Paused!");
        GodUI.SetActive(false);
        MenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void PlayGame()
    {
        Debug.Log("Play! " + SceneParametersManager.GetComponent<SceneParameters>().GetShowPlayButton());
        Resume();
    }

    public void RestartGame()
    {
        Debug.Log("Restarted! ");
        SceneManager.LoadScene("Main");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

}
