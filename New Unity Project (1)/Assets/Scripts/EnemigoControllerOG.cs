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

public class EnemigoControllerOG : MonoBehaviour
{

    public Camera cam;
    public Vector3 position;
    public NavMeshAgent agent;

    void Start()
    {
        position = GameObject.Find("astroplayer").transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        position = GameObject.Find("astroplayer").transform.position;

        agent.destination = position;


    }
}