using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool gamePause = false;
    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Menu()
    {
        //Cursor.visible = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    public void Resume()
    {
        //Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }

    public void Pause()
    {
        //Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }
}
