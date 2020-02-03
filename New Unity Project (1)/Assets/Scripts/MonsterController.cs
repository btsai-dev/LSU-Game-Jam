using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public AudioSource sound;
    public int numberCap = 1000;
    public bool active;
    GameObject player;
    GameObject hunter;
    GameObject chaser;
    int rand;

    void Start()
    {
        active = true;
        player = GameObject.FindGameObjectWithTag("Player");
        hunter = GameObject.FindGameObjectWithTag("Hunter");
        chaser = GameObject.FindGameObjectWithTag("Chaser");

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (active) { 
                agent.destination = player.transform.position;
                rand = Random.Range(0, numberCap);
                if (rand == 1)
                {
                    sound.Play();
                }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            active = false;
            PlayerController controller = player.GetComponent<PlayerController>();
            //Debug.Log("Hunter is KillingPlayer.");
            //Debug.Log(hunter.transform.position);
            if(chaser)
                chaser.SetActive(false);
            if(hunter)
                hunter.SetActive(false);
            controller.isAlive = false;
        }
    }
}