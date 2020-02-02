//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;

//public class EnemigoController : MonoBehaviour
//{

//    public Camera cam;
//    public Vector3 position;
//    public NavMeshAgent agent;
//    public NavMeshAgent agent2;
//    public NavMeshPath navMeshPath;

//    void Start()
//    {
//        position = GameObject.Find("Player").transform.position;

//        if (agent.CalculatePath(position))
//        {
//            NavMeshPath path = new navMeshPath();
//            agent.CalculatePath(position, path);
//        }

//    }
//    // Update is called once per frame
//    void FixedUpdate()
//    {
//        //position = GameObject.Find("Player").transform.position;

//       // if (!agent.CalculatePath(position))
//       // {   
//            path = new navMeshPath();
//            //agent2.CalculatePath(position, path);

//       // }

//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    GameObject player;
    GameObject hunter;
    GameObject chaser;

    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player");
        hunter = GameObject.FindGameObjectWithTag("Hunter");
        chaser = GameObject.FindGameObjectWithTag("Chaser");

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        agent.destination = player.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController controller = player.GetComponent<PlayerController>();
            Debug.Log("KillingPlayer.");
            controller.isAlive = false;
            if(chaser)
                chaser.SetActive(false);
            if(hunter)
                hunter.SetActive(false);
        }
    }
}