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
    public MeshRenderer mesh;
    public Collider coll;

    private bool active;
    private float spawnTime = 30f;
    private float timer = 0f;
    private float timeInLight = 0f;
    private float lightLimit = 0f;
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
        active = false;
        agent.isStopped = true;
        timer = 0f;
    }



    void FixedUpdate()
    {
        if(gamemaster.repaired >= 0) {
            if (!active)
            {
                if (!loaded)
                {
                    Debug.Log("Loaded and spawning!");
                    spawnIn();
                }
                else
                {
                    timer += Time.deltaTime;
                    if (timer > spawnTime)
                    {
                        spawnIn();
                        timer = 0f;
                    }
                }
                
            }
            else if (active)
            {
                Debug.Log("Chasing!");
                agent.destination = player.transform.position;
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "DangerLight" && active) {
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
        active = true;
        agent.isStopped = false;
        mesh.enabled = true;
        coll.enabled = true;
        loaded = true;
    }

    void terminate()
    {
        Debug.Log("Terminating.");
        agent.isStopped = true;
        coll.enabled = false;
        mesh.enabled = false;
        active = false;
        //chaser.transform.position = holdingCell;
        chaser.transform.position = new Vector3(-10, 0, 13);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (loaded && active && collision.gameObject.tag == "Player")
        {
            PlayerController controller = player.GetComponent<PlayerController>();
            Debug.Log("Chaser is Killing Player.");
            if(hunter)
                hunter.SetActive(false);
            if(chaser)
                chaser.SetActive(false);
            controller.isAlive = false;
        }
    }
}
