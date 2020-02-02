 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private AudioSource background;
    void Start()
    {
        background = GameObject.Find("Canvas").GetComponent<AudioSource>();
    }

    public void PlayGame()
    {
        background.Stop();
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; 
    }
}
