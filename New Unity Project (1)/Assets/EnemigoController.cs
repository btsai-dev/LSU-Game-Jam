using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoController : MonoBehaviour
{

    public Camera cam;
    public Vector3 position;
    public NavMeshAgent agent;

    void Start()
    {
        position = GameObject.Find("FamilyMan").transform.position;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
            position = GameObject.Find("FamilyMan").transform.position;

            agent.destination = position;
            
        
    }
}
