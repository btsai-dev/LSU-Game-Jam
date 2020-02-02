using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public int generators;
    public int repaired;
    public GameObject player;
    public PlayerController script; 
            
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        script = player.GetComponent<PlayerController>();
        generators = GameObject.FindGameObjectsWithTag("Generator").Length;
        repaired = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(repaired == generators)
        {
            SceneManager.LoadScene(3, LoadSceneMode.Single);
        } else if (!script.isAlive)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Single);
        }

        
    }

    void cleanUp()
    {
        GameObject hunter = GameObject.FindGameObjectWithTag("Hunter");
        GameObject chaser = GameObject.FindGameObjectWithTag("Chaser");
        if (hunter)
            hunter.SetActive(false);
        if (chaser)
            chaser.SetActive(false);
        if (player)
            player.SetActive(false);
    }
}
