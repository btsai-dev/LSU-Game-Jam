using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{

    GameObject hunter;
    GameObject chaser;
    public int generators;
    public int repaired;
    public bool started;
    public GameObject player;
    public PlayerController script;
    public AudioSource mainMusic;
            
    void Start()
    {
        hunter = GameObject.FindGameObjectWithTag("Hunter");
        chaser = GameObject.FindGameObjectWithTag("Chaser");
        player = GameObject.FindGameObjectWithTag("Player");
        script = player.GetComponent<PlayerController>();
        generators = GameObject.FindGameObjectsWithTag("Generator").Length;
        repaired = 0;

        script.isAlive = true;
        mainMusic.Play();
    }


    private void FixedUpdate()
    {
        if (repaired == generators)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        }
        else if (!script.isAlive)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }
    }

    void cleanUp()
    {
        if (hunter)
            hunter.SetActive(false);
        if (chaser)
            chaser.SetActive(false);
        if (player)
            player.SetActive(false);
    }
}
