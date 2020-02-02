using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaserController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    GameMaster gamemaster;
    GameObject player;
    GameObject chaser;
    GameObject hunter;


    private bool active;
    private float spawnTime = 30f;
    private float timer = 0f;
    private float timeInLight = 0f;
    private float lightLimit = 0f;
    private bool fading;
    private Material chaserMaterial;

    private float sTime;
    private Vector3 spawnLocation;
    private Vector3 holdingCell;
    private bool loaded;
    private float fadeSpeed = 0.1f;

    void Start()
    {
        loaded = false;
        sTime = Time.time;
        gamemaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameMaster>();
        player = GameObject.FindGameObjectWithTag("Player");
        chaser = GameObject.FindGameObjectWithTag("Chaser");
        hunter = GameObject.FindGameObjectWithTag("Hunter");
        spawnLocation = chaser.transform.position;
        holdingCell = GameObject.FindGameObjectWithTag("Prison").transform.position;
        chaserMaterial = GetComponent<Renderer>().material;
        fading = false;
        active = false;
    }

    void Update()
    {
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(gamemaster.repaired > 0) {
            if (!fading && !active)
            {
                if (!loaded)
                {
                    spawnIn();
                    loaded = true;
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer > spawnTime)
                    {
                        timer = 0f;
                        spawnIn();
                        active = true;
                    }
                }
                
            }
            else if (active && !fading)
            {
                Debug.Log("Chasing!");
                agent.destination = player.transform.position;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "DangerLight" && active && !fading) {
            if (timeInLight < lightLimit)
            {
                timeInLight += Time.deltaTime;
            }
            else
            {
                terminate();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        timeInLight = 0;
    }


    void spawnIn()
    {
        Debug.Log("Spawning in!");
        chaser.transform.position = spawnLocation;
        agent.isStopped = false;
        Color colora = chaser.GetComponent<Renderer>().material.color;
        colora.a = 1f;
    }

    void terminate()
    {
        agent.isStopped = true;
        active = false;
        chaser.transform.position = holdingCell;

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (active && !fading && collision.gameObject.tag == "Player")
        {
            PlayerController controller = player.GetComponent<PlayerController>();
            Debug.Log("KillingPlayer.");
            controller.isAlive = false;
            if(hunter)
                hunter.SetActive(false);
            if(chaser)
                chaser.SetActive(false);
        }
    }
}
